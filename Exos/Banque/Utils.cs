﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banque
{
    class Utils
    {
        Dictionary<int, Account> accounts = new Dictionary<int, Account>();
        Dictionary<int, Transaction> transactions = new Dictionary<int, Transaction>();

        public void readAccounts(string acctPath)
        {
            using (StreamReader sr = new StreamReader(acctPath))
            {
                while (!sr.EndOfStream)
                {
                    int id;
                    double balance = 0;
                    string sBalance = "";
                    string[] data = sr.ReadLine().Split(';');
                    if (data.Length > 0)
                    {
                        string sId = data[0];
                        if (data.Length > 1)
                        {
                            sBalance = data[1].Trim();
                        }
                        // Account id is valid and not already used
                        if (int.TryParse(sId, out id) && !accounts.ContainsKey(id))
                        {
                            if (sBalance == "")
                                accounts.Add(id, new Account(id));
                            else if (double.TryParse(sBalance, out balance))
                                accounts.Add(id, new Account(id, balance));
                        }
                    }
                }
            }
        }

        public void readTransactions(string trxnPath)
        {
            using (StreamReader sr = new StreamReader(trxnPath))
            {
                int invalidId = 0;
                while (!sr.EndOfStream)
                {
                    string rawData = sr.ReadLine();
                    string[] data = rawData.Split(';');
                    string sId = data[0];
                    string sAmount = data[1];
                    string sTransmitter = data[2];
                    string sRecipient = data[3];
                    int id;
                    double amount;
                    int transmitter;
                    int recipient;
                    Transaction transaction;
                    // Transaction data is valid and id is not already used
                    if (int.TryParse(sId, out id) &&
                        double.TryParse(sAmount, out amount) &&
                        int.TryParse(sTransmitter, out transmitter) &&
                        int.TryParse(sRecipient, out recipient) &&
                        !transactions.ContainsKey(id))
                    {
                        transaction = new Transaction(
                                Transaction.TransactionType.Transfer,
                                Transaction.TransactionStatus.OK,
                                "",
                                id,
                                amount,
                                transmitter,
                                recipient);

                        if (transmitter == 0 && recipient != 0)
                        {
                            transaction.Type = Transaction.TransactionType.Deposition;
                        }
                        else if (recipient == 0 && transmitter != 0)
                        {
                            transaction.Type = Transaction.TransactionType.Withdrawal;
                        }
                        else if (recipient == 0 && transmitter == 0)
                            transaction.Status = Transaction.TransactionStatus.KO;
                        transactions.Add(id, transaction);

                    }
                    // At least transaction id is valid and id is not already used
                    else if (int.TryParse(sId, out id) && !transactions.ContainsKey(id))
                    {
                        transaction = new Transaction(
                            Transaction.TransactionType.Transfer,
                            Transaction.TransactionStatus.KO,
                            rawData,
                            id);
                        transactions.Add(id, transaction);
                    }
                    // Transaction id is invalid or already used
                    else
                    {
                        transaction = new Transaction(
                            Transaction.TransactionType.Transfer,
                            Transaction.TransactionStatus.KO,
                            rawData);
                        transactions.Add(--invalidId, transaction);
                    }
                }
            }
        }

        public void writeTransactionsStatus(string sttsTrxnPath)
        {
            using (StreamWriter sw = new StreamWriter(sttsTrxnPath))
            {
                TryTransactions();
                foreach (var t in transactions)
                {
                    sw.WriteLine($"{t.Key};{t.Value.Status}");

                }
            };
        }

        private void TryTransactions()
        {
            foreach (var t in transactions)
            {
                Console.WriteLine($"     {accounts[1].Balance} " +
                $"{accounts[2].Balance} {accounts[3].Balance}");
                if (t.Value.Status == Transaction.TransactionStatus.OK)
                {
                    if (t.Value.Type == Transaction.TransactionType.Deposition)
                    {
                        if (accounts.ContainsKey(t.Value.Recipient))
                        {
                            if (accounts[t.Value.Recipient].Deposit(t.Value.Amount, t.Value))
                                t.Value.Status = Transaction.TransactionStatus.OK;
                            else
                                t.Value.Status = Transaction.TransactionStatus.KO;
                        }
                        else
                            t.Value.Status = Transaction.TransactionStatus.KO;

                    }
                    if (t.Value.Type == Transaction.TransactionType.Withdrawal)
                    {
                        if (accounts.ContainsKey(t.Value.Transmitter))
                        {
                            if (accounts[t.Value.Transmitter].Withdraw(t.Value.Amount, t.Value))
                                t.Value.Status = Transaction.TransactionStatus.OK;
                            else
                                t.Value.Status = Transaction.TransactionStatus.KO;
                        }
                        else
                            t.Value.Status = Transaction.TransactionStatus.KO;
                    }
                    if (t.Value.Type == Transaction.TransactionType.Transfer)
                    {
                        if (accounts.ContainsKey(t.Value.Transmitter) &&
                            accounts.ContainsKey(t.Value.Recipient) &&
                            t.Value.Recipient != t.Value.Transmitter)
                        {
                            if (t.Value.Amount > 0 && accounts[t.Value.Transmitter].Withdraw(t.Value.Amount, t.Value))
                            {
                                Transaction transaction = new Transaction(
                                    Transaction.TransactionType.Levy,
                                    Transaction.TransactionStatus.OK,
                                    "",
                                    t.Value.Id,
                                    t.Value.Amount,
                                    t.Value.Recipient,
                                    t.Value.Transmitter);
                                accounts[t.Value.Recipient].Deposit(t.Value.Amount, transaction);
                                t.Value.Status = Transaction.TransactionStatus.OK;
                            }
                            else
                                t.Value.Status = Transaction.TransactionStatus.KO;
                        }
                        else
                            t.Value.Status = Transaction.TransactionStatus.KO;
                    }
                }
                Console.WriteLine($"{t.Key} {t.Value.Status} {accounts[1].Balance} " +
                $"{accounts[2].Balance} {accounts[3].Balance}");
            }
        }
    }
}