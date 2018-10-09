using System;

public class Rules: ICore
{   
    
    private string _name;
    private string _description;

	public Rules()
	{
	}

    public int GetID()
    {
        throw new NotImplementedException();
    }

    public string GetRowId()
    {
        throw new NotImplementedException();
    }

    public void Modify(string rowId)
    {
        throw new NotImplementedException();
    }

    public void Remove(string rowId)
    {
        throw new NotImplementedException();
    }
}
