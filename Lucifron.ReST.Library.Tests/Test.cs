using System.Collections.Generic;

namespace Lucifron.ReST.Library.Tests
{
    public interface ICanAddCondition
    {
        ICanAddWhereValue Where(string columnName);

        void AllRows();
    }

    public interface ICanAddWhereOrRun
    {
        ICanAddWhereValue Where(string columnName);

        void RunNow();
    }

    public interface ICanAddWhereValue
    {
        ICanAddWhereOrRun IsEqualTo(object value);

        ICanAddWhereOrRun IsNotEqualTo(object value);
    }

    public class WhereCondition
    {
        public enum ComparisonMethod
        {
            EqualTo,
            NotEqualTo
        }

        public string ColumnName { get; private set; }
        public ComparisonMethod Comparator { get; private set; }
        public object Value { get; private set; }

        public WhereCondition(string columnName, ComparisonMethod comparator, object value)
        {
            ColumnName = columnName;
            Comparator = comparator;
            Value = value;
        }
    }

    public class DeleteQueryWithoutGrammar
    {
        private readonly string _tableName;
        private readonly List<WhereCondition> _whereConditions = new List<WhereCondition>();

        private string _currentWhereConditionColumn;

        // Private constructor, to force object instantiation from the fluent method(s)
        private DeleteQueryWithoutGrammar(string tableName)
        {
            _tableName = tableName;
        }

        #region Initiating Method(s)

        public static DeleteQueryWithoutGrammar DeleteRowsFrom(string tableName)
        {
            return new DeleteQueryWithoutGrammar(tableName);
        }

        #endregion Initiating Method(s)

        #region Chaining Method(s)

        public DeleteQueryWithoutGrammar Where(string columnName)
        {
            _currentWhereConditionColumn = columnName;

            return this;
        }

        public DeleteQueryWithoutGrammar IsEqualTo(object value)
        {
            _whereConditions.Add(new WhereCondition(_currentWhereConditionColumn, WhereCondition.ComparisonMethod.EqualTo, value));

            return this;
        }

        public DeleteQueryWithoutGrammar IsNotEqualTo(object value)
        {
            _whereConditions.Add(new WhereCondition(_currentWhereConditionColumn, WhereCondition.ComparisonMethod.NotEqualTo, value));

            return this;
        }

        #endregion Chaining Method(s)

        #region Executing Method(s)

        public void AllRows()
        {
            ExecuteThisQuery();
        }

        public void RunNow()
        {
            ExecuteThisQuery();
        }

        #endregion Executing Method(s)

        private void ExecuteThisQuery()
        {
            // Code to build and execute the delete query
        }
    }

    public class DeleteQueryWithGrammar : ICanAddCondition, ICanAddWhereValue, ICanAddWhereOrRun
    {
        private readonly string _tableName;
        private readonly List<WhereCondition> _whereConditions = new List<WhereCondition>();

        private string _currentWhereConditionColumn;

        // Private constructor, to force object instantiation from the fluent method(s)
        private DeleteQueryWithGrammar(string tableName)
        {
            _tableName = tableName;
        }

        #region Initiating Method(s)

        public static ICanAddCondition DeleteRowsFrom(string tableName)
        {
            return new DeleteQueryWithGrammar(tableName);
        }

        #endregion Initiating Method(s)

        #region Chaining Method(s)

        public ICanAddWhereValue Where(string columnName)
        {
            _currentWhereConditionColumn = columnName;

            return this;
        }

        public ICanAddWhereOrRun IsEqualTo(object value)
        {
            _whereConditions.Add(new WhereCondition(_currentWhereConditionColumn, WhereCondition.ComparisonMethod.EqualTo, value));

            return this;
        }

        public ICanAddWhereOrRun IsNotEqualTo(object value)
        {
            _whereConditions.Add(new WhereCondition(_currentWhereConditionColumn, WhereCondition.ComparisonMethod.NotEqualTo, value));

            return this;
        }

        #endregion Chaining Method(s)

        #region Executing Method(s)

        public void AllRows()
        {
            ExecuteThisQuery();
        }

        public void RunNow()
        {
            ExecuteThisQuery();
        }

        #endregion Executing Method(s)

        private void ExecuteThisQuery()
        {
            // Code to build and execute the delete query
        }
    }
}