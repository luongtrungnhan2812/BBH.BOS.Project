﻿using BBC.Core.Database;
using BBH.BOS.Domain.Entities;
using BBH.BOS.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBH.BOS.Data
{
    public class TransactionPackageBusiness: ITransactionPackageService
    {
        public static string pathLog = ConfigurationManager.AppSettings["PathLog"];
        static string fileLog = Path.GetDirectoryName(Path.Combine(pathLog, "Logs"));
        public bool InsertTransactionPackage(TransactionPackageBO transaction)
        {
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                bool rs = false;
                string sql = "SP_InsertTransactionPackageFE";
                SqlParameter[] pa = new SqlParameter[9];
                pa[0] = new SqlParameter("@memberid", transaction.MemberID);
                pa[1] = new SqlParameter("@packageid", transaction.PackageID);
                pa[2] = new SqlParameter("@coinid", transaction.CoinID);
                pa[3] = new SqlParameter("@createdate", transaction.CreateDate);
                pa[4] = new SqlParameter("@expiredate", transaction.ExpireDate);
                pa[5] = new SqlParameter("@status", transaction.Status);
                pa[6] = new SqlParameter("@transactioncode", transaction.TransactionCode);
                pa[7] = new SqlParameter("@note", transaction.Note);
                pa[8] = new SqlParameter("@transactionbitcoin", transaction.TransactionBitcoin);
                SqlCommand command = helper.GetCommand(sql, pa, true);
                int row = command.ExecuteNonQuery();
                if (row > 0)
                {
                    rs = true;
                }
                return rs;
            }
            catch (Exception ex)
            {
                Utilitys.WriteLog(fileLog, ex.Message);
                return false;
            }
            finally
            {
                helper.destroy();
            }
        }
        public IEnumerable<TransactionPackageBO> ListTransactionPackageByMember(int memberID)
        {
            Sqlhelper helper = new Sqlhelper("", "ConnectionString");
            try
            {
                List<TransactionPackageBO> lstTransaction = new List<TransactionPackageBO>();
                string sql = "SP_ListTransactionByMember";
                SqlParameter[] pa = new SqlParameter[1];
                pa[0] = new SqlParameter("@memberID", memberID);
                SqlCommand command = helper.GetCommand(sql, pa, true);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    TransactionPackageBO transaction = new TransactionPackageBO();
                    transaction.MemberID = int.Parse(reader["MemberID"].ToString());
                    transaction.Status = int.Parse(reader["Status"].ToString());
                    transaction.CoinID = int.Parse(reader["CoinID"].ToString());
                    transaction.CreateDate = DateTime.Parse(reader["CreateDate"].ToString());
                    transaction.ExpireDate = DateTime.Parse(reader["ExpireDate"].ToString());
                    transaction.PackageID = int.Parse(reader["PackageID"].ToString());
                    transaction.PackageName = reader["PackageName"].ToString();
                    transaction.TransactionCode = reader["TransactionCode"].ToString();
                    transaction.Note = reader["Note"].ToString();
                    lstTransaction.Add(transaction);

                }
                return lstTransaction;
            }
            catch (Exception ex)
            {
                Utilitys.WriteLog(fileLog, ex.Message);
                return null;
            }
            finally
            {
                helper.destroy();
            }
        }
    }
}
