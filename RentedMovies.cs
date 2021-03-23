﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRentalStore
{
    class RentedMovies
    {
        Database rentedMoviesDatabase = new Database();

        public DataView ReadEntries()
        {
            string selectFields = "*";
            string tableName = "CustomerAndMoviesRented";
            string whereClause = "";
            return rentedMoviesDatabase.ReadEntries(selectFields, tableName, whereClause);
        }

        public DataView ReadMostPopularMovies()
        {
            string selectFields = "*";
            string tableName = "MoviesRented";
            string whereClause = "";
            return rentedMoviesDatabase.ReadEntries(selectFields, tableName, whereClause);
        }

        public DataView ReadBestCustomers()
        {
            string selectFields = "*";
            string tableName = "CustomersRentedMovies";
            string whereClause = "";
            return rentedMoviesDatabase.ReadEntries(selectFields, tableName, whereClause);
        }

        public DataView ReadAvailableMovies()
        {
            string selectFields = "*";
            string tableName = "AvalMovies";
            string whereClause = "";
            return rentedMoviesDatabase.ReadEntries(selectFields, tableName, whereClause);
        }

        public DataView ReadRentedOutMovies()
        {
            string selectFields = "*";
            string tableName = "RentedMovies_v_Customer_v_Movies";
            string whereClause = "";
            return rentedMoviesDatabase.ReadEntries(selectFields, tableName, whereClause);
        }

        public bool IssueMovie(string[] insertArr)
        {
            string tableName = "RentedMovies";
            // parameterDefine, parameterAssign & insertArr need to be the same length.
            string parameterDefine = "@MovieIDFK, @CustIDFK, @DateRented, @DateReturned";
            string[] parameterAssign = { "@MovieIDFK", "@CustIDFK", "@DateRented", "@DateReturned" };
            return rentedMoviesDatabase.CreateEntry(tableName, parameterDefine, parameterAssign, insertArr);
        }

        public bool ReturnMovie(string[] updateArr)
        {
            string tableName = "RentedMovies";
            string setFields = "DateReturned=@DateReturned";
            string whereClause = "WHERE RMID=@RMID";
            string[] parameterAssign = { "@DateReturned", "@RMID" };
            return rentedMoviesDatabase.UpdateEntry(tableName, setFields, whereClause, parameterAssign, updateArr);
        }
    }
}
