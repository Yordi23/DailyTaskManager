using System;
public class Activities: ICore
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

    public Activities(string name,string description, string place, DateTime date, byte priority)
    {
        _pendent = true;
        _id = GetID();
        _rowId = GetRowId();
        _name = name;
        _description = description;
        _place = place;
        _date = date;
        _priority = priority;

    }
    public string Name
    {
        get =>_name;
    }
    public string Description
    {
        get =>_description;
    }
    public string Place
    {
        get =>_place;
    }

    public void Complete()
    {
        _pendent = false;
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
        return 2;
    }

    public string GetRowId()
    {
        return "algoai";
    }
}
