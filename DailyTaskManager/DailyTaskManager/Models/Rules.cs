using System;

public class Rules: ICore
{   
    
    private string name;
    private string description;

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
