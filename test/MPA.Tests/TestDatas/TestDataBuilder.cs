using MPA.EntityFrameworkCore;

namespace MPA.Tests.TestDatas;

public class TestDataBuilder
{
    private readonly MPADbContext _context;

    public TestDataBuilder(MPADbContext context)
    {
        _context = context;
    }

    public void Build()
    {
        //create test data here...
    }
}