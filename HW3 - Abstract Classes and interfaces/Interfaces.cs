public interface IOutput
{
    void Show();
    void Show(string info);
}

public interface  IMath 
{
    int Max();
    int Min();
    float Avg();
    bool Search(int valueToFind);
}


public interface ISort 
    {
    void SortAscending();
    void SortDescending();

    void SortByParam(bool isAscending);
}
