using System;

public interface ICore
{
    int GetID();
    string GetRowId();
    void Remove(string rowId);
    void Modify(string rowId);
}
