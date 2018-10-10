using System;
using SQLite;

namespace DailyTaskManager.Models
{
    public class Item: ICore
    {
        
        private int _id;
        private string _rowId;
        private bool _pendent;
        private string _name;
        private string _description;
        private string _place;
        private DateTime _date;
        private Rules _warningRules;
        private Byte _priority;
        public string RowId { get => _rowId; set => _rowId = value; }
        public bool Pendent { get => _pendent; set => _pendent = value; }
        public string Name { get => _name; set => _name = value; }
        public string Description { get => _description; set => _description = value; }
        public string Place { get => _place; set => _place = value; }
        public DateTime Date { get => _date; set => _date = value; }
        public Rules WarningRules { get => _warningRules; set => _warningRules = value; }
        public byte Priority { get => _priority; set => _priority = value; }
        public int Id { get => _id; set => _id = value; }

        public Item(string name, string description, string place, DateTime date, byte priority)
        {
            Pendent = true;
            _id = GetID();
            //_rowId = GetRowId();
            Name = name;
            Description = description;
            Place = place;
            _date = date;
            _priority = priority;

        }
        public Item()
        {

        }

        public Item(int id,string rid, bool pendent, string name, string description, string place, DateTime date, Rules warningRules, byte priority)
        {
            _id = id;
            _rowId = rid;
            _pendent = pendent;
            _name = name;
            _description = description;
            _place = place;
            _date = date;
            _warningRules = warningRules;
            _priority = priority;
        }

        public void Complete()
        {
            Pendent = false;
        }
        public void AddRule(Rules rule)
        {
            
        }

        public void Remove(string rowId)
        {
            throw new NotImplementedException();
        }

        public void Modify(string rowId)
        {
            throw new NotImplementedException();
        }

        public int GetID()
        {
            return _id;
        }
        /*
        public string GetRowId()
        {
            return _rowId;
        }*/
    }
}