﻿using BccCode.Linq.Async;

namespace BccCode.Linq.Tests;

public class LinqQueryProviderTests
{
    #region ElementAt

    [Fact]
    public void ElementAtTest()
    {
        var api = new ApiClientMockup();

        var persons = api.Persons.ElementAt(2);
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Equal(2, api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret ElementAt clauses. Since we remove the ElementAt clause
        //       from the expression tree, the result will be still the first element of the mockup data.
        //Assert.Equal("Chelsey Logan", persons.Name);
        Assert.Equal("Archibald Mcbride", persons.Name);
    }
    
    [Fact]
    public async void ElementAtAsyncTest()
    {
        var api = new ApiClientMockup();

        var persons = await api.Persons.ElementAtAsync(2);
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Equal(2, api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret ElementAt clauses. Since we remove the ElementAt clause
        //       from the expression tree, the result will be still the first element of the mockup data.
        //Assert.Equal("Chelsey Logan", persons.Name);
        Assert.Equal("Archibald Mcbride", persons.Name);
    }
    
    #endregion

    #region ElementAtOrDefault
    
    [Fact]
    public void ElementAtOrDefaultTest()
    {
        var api = new ApiClientMockup();

        var persons = api.Persons.ElementAtOrDefault(2);
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Equal(2, api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret ElementAt clauses. Since we remove the ElementAt clause
        //       from the expression tree, the result will be still the first element of the mockup data.
        //Assert.Equal("Chelsey Logan", persons.Name);
        Assert.Equal("Archibald Mcbride", persons?.Name);
    }
    
    [Fact]
    public async void ElementAtOrDefaultAsyncTest()
    {
        var api = new ApiClientMockup();

        var persons = await api.Persons.ElementAtOrDefaultAsync(2);
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Equal(2, api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret ElementAt clauses. Since we remove the ElementAt clause
        //       from the expression tree, the result will be still the first element of the mockup data.
        //Assert.Equal("Chelsey Logan", persons.Name);
        Assert.Equal("Archibald Mcbride", persons?.Name);
    }
    
    [Fact]
    public void ElementAtOrDefaultNotFoundTest()
    {
        var api = new ApiClientMockup();

        var persons = api.Persons.ElementAtOrDefault(int.MaxValue);
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Equal(int.MaxValue, api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret ElementAt clauses. Since we remove the ElementAt clause
        //       from the expression tree, the result will be still the first element of the mockup data.
        //Assert.Equal(null, persons.Name);
        Assert.Equal("Archibald Mcbride", persons?.Name);
    }
    
    [Fact]
    public void ElementAtOrDefaultEmptyTest()
    {
        var api = new ApiClientMockup();

        var testClass = api.Empty.ElementAtOrDefault(0);
        Assert.Equal("empty", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Equal(0, api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        Assert.Null(testClass);
    }
    
    [Fact]
    public async void ElementAtOrDefaultNotFoundAsyncTest()
    {
        var api = new ApiClientMockup();

        var persons = await api.Persons.ElementAtOrDefaultAsync(int.MaxValue);
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Equal(int.MaxValue, api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret ElementAt clauses. Since we remove the ElementAt clause
        //       from the expression tree, the result will be still the first element of the mockup data.
        //Assert.Equal(null, persons.Name);
        Assert.Equal("Archibald Mcbride", persons?.Name);
    }

    #endregion

    #region First

    [Fact]
    public void FirstTest()
    {
        var api = new ApiClientMockup();

        var persons = api.Persons.First();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        Assert.Equal("Archibald Mcbride", persons.Name);
    }
    
    [Fact]
    public async void FirstAsyncTest()
    {
        var api = new ApiClientMockup();

        var persons = await api.Persons.FirstAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        Assert.Equal("Archibald Mcbride", persons.Name);
    }

    #endregion
    
    #region FirstOrDefault

    [Fact]
    public void FirstOrDefaultTest()
    {
        var api = new ApiClientMockup();

        var persons = api.Persons.FirstOrDefault();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        Assert.Equal("Archibald Mcbride", persons?.Name);
    }
    
    [Fact]
    public void FirstOrDefaultEmptyTest()
    {
        var api = new ApiClientMockup();

        var testClass = api.Empty.FirstOrDefault();
        Assert.Equal("empty", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        Assert.Null(testClass);
    }
    
    [Fact]
    public async void FirstOrDefaultAsyncTest()
    {
        var api = new ApiClientMockup();

        var persons = await api.Persons.FirstOrDefaultAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        Assert.Equal("Archibald Mcbride", persons?.Name);
    }
    
    [Fact]
    public async void FirstOrDefaultEmptyAsyncTest()
    {
        var api = new ApiClientMockup();

        var testClass = await api.Empty.FirstOrDefaultAsync();
        Assert.Equal("empty", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        Assert.Null(testClass);
    }

    #endregion
    
    #region Select

    [Fact]
    public void SelectTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            select p;

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public void SelectSingleStringFieldTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            select p.Name;

        // Currently not supported
        Assert.Throws<Exception>(() =>
        {
            // ReSharper disable once UnusedVariable
            var persons = query.ToList();
        });
    }

    [Fact]
    public void SelectSingleIntegerFieldTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            select p.Age;

        // Currently not supported
        Assert.Throws<Exception>(() =>
        {
            // ReSharper disable once UnusedVariable
            var persons = query.ToList();
        });
    }

    [Fact]
    public void SelectNewSingleFieldTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            select new
            {
                p.Name
            };

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("name", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public void SelectNewNestedSingleFieldIfNullTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            select new
            {
                Manufacturer = p.Car == null ? null : p.Car.Manufacturer
            };

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("car,car.manufacturer", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public void SelectNewTwoFieldsTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            select new
            {
                p.Name,
                p.Age
            };

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("name,age", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        Assert.Equal(5, persons.Count);
    }

    #endregion

    #region Single

    [Fact]
    public void SingleTest()
    {
        var api = new ApiClientMockup();

        Assert.Throws<InvalidOperationException>(() =>
        {
            // ReSharper disable once UnusedVariable
            var persons = api.Persons.Single();
        });
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(2, api.LastRequest?.Limit);
    }
    
    [Fact]
    public void SingleAsyncTest()
    {
        var api = new ApiClientMockup();

        Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            // ReSharper disable once UnusedVariable
            var persons = await api.Persons.SingleAsync();
        });
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(2, api.LastRequest?.Limit);
    }

    #endregion

    #region SingleOrDefault

    [Fact] public void SingleOrDefaultTest()
    {
        var api = new ApiClientMockup();

        Assert.Throws<InvalidOperationException>(() =>
        {
            // ReSharper disable once UnusedVariable
            var persons = api.Persons.SingleOrDefault();
        });
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(2, api.LastRequest?.Limit);
    }
    
    [Fact]
    public void SingleOrDefaultEmptyTest()
    {
        var api = new ApiClientMockup();

        var testClass = api.Empty.SingleOrDefault();
        Assert.Equal("empty", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(2, api.LastRequest?.Limit);
        Assert.Null(testClass);
    }
    
    [Fact]
    public void SingleOrDefaultAsyncTest()
    {
        var api = new ApiClientMockup();

        Assert.ThrowsAsync<InvalidOperationException>(async () =>
        {
            // ReSharper disable once UnusedVariable
            var persons = await api.Persons.SingleOrDefaultAsync();
        });
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(2, api.LastRequest?.Limit);
    }
    
    [Fact]
    public async void SingleOrDefaultEmptyAsyncTest()
    {
        var api = new ApiClientMockup();

        var testClass = await api.Empty.SingleOrDefaultAsync();
        Assert.Equal("empty", api.LastEndpoint);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(2, api.LastRequest?.Limit);
        Assert.Null(testClass);
    }
    
    #endregion
    
    #region Where

    [Fact]
    public void WhereGuidEqualStaticNewTest()
    {
        var api = new ApiClientMockup();

        var query =
            from m in api.Manufacturers
            // here the constructor for 'Guid' is called during expression tree validation (client side invocation)
            where m.Uid == new Guid("16b41e40-ee3c-4837-b9a9-57b76c7d1d9d")
            select m;

        var manufacturer = query.FirstOrDefault();
        Assert.Equal("manufacturers", api.LastEndpoint);
        Assert.Equal("{\"uid\": {\"_eq\": \"16b41e40-ee3c-4837-b9a9-57b76c7d1d9d\"}}", api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        Assert.NotNull(manufacturer);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the first row of the mockup data.
        //Assert.Equal(new Guid("16b41e40-ee3c-4837-b9a9-57b76c7d1d9d"), manufacturer?.Uid);
        Assert.Equal(new Guid("4477e983-be5c-43d5-b3d0-5f26971bf2f3"), manufacturer?.Uid);
    }
    
    [Fact]
    public void WhereGuidEqualStaticMethodCallTest()
    {
        var api = new ApiClientMockup();

        var query =
            from m in api.Manufacturers
            // here the method 'Guid.Parse' is called during expression tree validation (client side invocation)
            where m.Uid == Guid.Parse("16b41e40-ee3c-4837-b9a9-57b76c7d1d9d")
            select m;

        var manufacturer = query.FirstOrDefault();
        Assert.Equal("manufacturers", api.LastEndpoint);
        Assert.Equal("{\"uid\": {\"_eq\": \"16b41e40-ee3c-4837-b9a9-57b76c7d1d9d\"}}", api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        Assert.NotNull(manufacturer);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the first row of the mockup data.
        //Assert.Equal(new Guid("16b41e40-ee3c-4837-b9a9-57b76c7d1d9d"), manufacturer?.Uid);
        Assert.Equal(new Guid("4477e983-be5c-43d5-b3d0-5f26971bf2f3"), manufacturer?.Uid);
    }
    
    [Fact]
    public void WhereGuidEqualLocalVariableTest()
    {
        var api = new ApiClientMockup();

        var uid = Guid.Parse("16b41e40-ee3c-4837-b9a9-57b76c7d1d9d");
        
        var query =
            from m in api.Manufacturers
            // here we use a local variable which will be evaluated on client side
            where m.Uid == uid
            select m;

        var manufacturer = query.FirstOrDefault();
        Assert.Equal("manufacturers", api.LastEndpoint);
        Assert.Equal("{\"uid\": {\"_eq\": \"16b41e40-ee3c-4837-b9a9-57b76c7d1d9d\"}}", api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        Assert.NotNull(manufacturer);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the first row of the mockup data.
        //Assert.Equal(new Guid("16b41e40-ee3c-4837-b9a9-57b76c7d1d9d"), manufacturer?.Uid);
        Assert.Equal(new Guid("4477e983-be5c-43d5-b3d0-5f26971bf2f3"), manufacturer?.Uid);
    }
    
    [Fact]
    public void WhereGuidEqualRemoteToStringTest()
    {
        var api = new ApiClientMockup();

        var query =
            from m in api.Manufacturers

            // It is invalid to call a method on a server-side property. This will not work.
            where m.Uid.ToString() == "16b41e40-ee3c-4837-b9a9-57b76c7d1d9d"
            select m;

        Assert.Throws<NotSupportedException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var manufacturer = query.FirstOrDefault();
            }
        );
        
        /*
        var manufacturer = query.FirstOrDefault();
        Assert.Equal("manufacturers", api.LastEndpoint);
        Assert.Equal("{\"uid\": {\"_eq\": \"16b41e40-ee3c-4837-b9a9-57b76c7d1d9d\"}}", api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(1, api.LastRequest?.Limit);
        Assert.NotNull(manufacturer);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the first row of the mockup data.
        //Assert.Equal(new Guid("16b41e40-ee3c-4837-b9a9-57b76c7d1d9d"), manufacturer?.Uid);
        Assert.Equal(new Guid("4477e983-be5c-43d5-b3d0-5f26971bf2f3"), manufacturer?.Uid);
        */
    }

    [Fact]
    public void WhereIntGreaterThanTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where p.Age > 26
            select p;

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("{\"age\": {\"_gt\": 26}}", api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(2, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public async void WhereIntGreaterThanAsyncTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where p.Age > 26
            select p;

        var persons = await query.ToListAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("{\"age\": {\"_gt\": 26}}", api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(2, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public void WhereIntNotGreaterThanTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where !(p.Age > 26)
            select p;

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("{\"age\": {\"_lte\": 26}}", api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(2, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public async void WhereIntNotGreaterThanAsyncTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where !(p.Age > 26)
            select p;

        var persons = await query.ToListAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("{\"age\": {\"_lte\": 26}}", api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(2, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public void WhereSelectAndTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where p.Age > 26 && p.Name == "Reid Cantrell"
            select new
            {
                p.Country
            };

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("{\"_and\": [{\"age\": {\"_gt\": 26}}, {\"name\": {\"_eq\": \"Reid Cantrell\"}}]}",
            api.LastRequest?.Filter);
        Assert.Equal("country", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(1, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public async void WhereSelectAndAsyncTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where p.Age > 26 && p.Name == "Reid Cantrell"
            select new
            {
                p.Country
            };

        var persons = await query.ToListAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("{\"_and\": [{\"age\": {\"_gt\": 26}}, {\"name\": {\"_eq\": \"Reid Cantrell\"}}]}",
            api.LastRequest?.Filter);
        Assert.Equal("country", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);

        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(1, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public void WhereSelectOrTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where p.Age > 26 || p.Name == "Chelsey Logan"
            select new
            {
                p.Country,
                p.Name
            };

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("{\"_or\": [{\"age\": {\"_gt\": 26}}, {\"name\": {\"_eq\": \"Chelsey Logan\"}}]}",
            api.LastRequest?.Filter);
        Assert.Equal("country,name", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(3, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public async void WhereSelectOrAsyncTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where p.Age > 26 || p.Name == "Chelsey Logan"
            select new
            {
                p.Country,
                p.Name
            };

        var persons = await query.ToListAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal("{\"_or\": [{\"age\": {\"_gt\": 26}}, {\"name\": {\"_eq\": \"Chelsey Logan\"}}]}",
            api.LastRequest?.Filter);
        Assert.Equal("country,name", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(3, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public void WhereSelectOrTwiceTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where p.Age > 26 || p.Name == "Chelsey Logan" || p.Country == "US"
            select new
            {
                p.Country,
                p.Name
            };

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal(
            "{\"_or\": [{\"_or\": [{\"age\": {\"_gt\": 26}}, {\"name\": {\"_eq\": \"Chelsey Logan\"}}]}, {\"country\": {\"_eq\": \"US\"}}]}",
            api.LastRequest?.Filter);
        Assert.Equal("country,name", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(4, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public async void WhereSelectOrTwiceAsyncTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where p.Age > 26 || p.Name == "Chelsey Logan" || p.Country == "US"
            select new
            {
                p.Country,
                p.Name
            };

        var persons = await query.ToListAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal(
            "{\"_or\": [{\"_or\": [{\"age\": {\"_gt\": 26}}, {\"name\": {\"_eq\": \"Chelsey Logan\"}}]}, {\"country\": {\"_eq\": \"US\"}}]}",
            api.LastRequest?.Filter);
        Assert.Equal("country,name", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(4, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public void StringStartsWithTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where p.Name.StartsWith("Chelsey")
            select p;

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal(
            "{\"name\": {\"_starts_with\": \"Chelsey\"}}",
            api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(1, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public async void StringStartsWithAsyncTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where p.Name.StartsWith("Chelsey")
            select p;

        var persons = await query.ToListAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal(
            "{\"name\": {\"_starts_with\": \"Chelsey\"}}",
            api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(1, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public void WhereStringEndsWithTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where p.Name.EndsWith("Cantrell")
            select p;

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal(
            "{\"name\": {\"_ends_with\": \"Cantrell\"}}",
            api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(1, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public async void WhereStringEndsWithAsyncTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where p.Name.EndsWith("Cantrell")
            select p;

        var persons = await query.ToListAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal(
            "{\"name\": {\"_ends_with\": \"Cantrell\"}}",
            api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(1, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public void WhereStringIsNullOrEmptyTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where string.IsNullOrEmpty(p.Name)
            select p;

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal(
            "{\"name\": {\"_empty\": null}}",
            api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(0, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public async void WhereStringIsNullOrEmptyAsyncTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where string.IsNullOrEmpty(p.Name)
            select p;

        var persons = await query.ToListAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal(
            "{\"name\": {\"_empty\": null}}",
            api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(0, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public void WhereNestedEqualTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where p.Car != null && Equals(p.Car.Model, "Opel")
            select p;

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal(
            "{\"_and\": [{\"car\": {\"_neq\": null}}, {\"car\": {\"model\": {\"_eq\": \"Opel\"}}}]}",
            api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(2, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public async void WhereNestedEqualAsyncTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            where p.Car != null && Equals(p.Car.Model, "Opel")
            select p;

        var persons = await query.ToListAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Equal(
            "{\"_and\": [{\"car\": {\"_neq\": null}}, {\"car\": {\"model\": {\"_eq\": \"Opel\"}}}]}",
            api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        // NOTE: Currently the Mockup API Client does not interpret Where clauses. Since we remove the Where clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(2, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    #endregion

    #region OrderBy

    [Fact]
    public void OrderByTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            orderby p.Name
            select p;

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Null(api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Equal("name", api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public async void OrderByAsyncTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            orderby p.Name
            select p;

        var persons = await query.ToListAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Null(api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Equal("name", api.LastRequest?.Sort);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public void OrderByDescendingTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            orderby p.Name descending
            select p;

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Null(api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Equal("-name", api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public async void OrderByDescendingAsyncTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            orderby p.Name descending
            select p;

        var persons = await query.ToListAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Null(api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Equal("-name", api.LastRequest?.Sort);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public void OrderByMultipleColumnsTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            orderby p.Name, p.Age descending, p.Country
            select p;

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Null(api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Equal("name,-age,country", api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public async void OrderByMultipleColumnsAsyncTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            orderby p.Name, p.Age descending, p.Country
            select p;

        var persons = await query.ToListAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Null(api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Equal("name,-age,country", api.LastRequest?.Sort);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public void OrderByNestingTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            orderby p.Car.Manufacturer
            select p;

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Null(api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Equal("car.manufacturer", api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        Assert.Equal(5, persons.Count);
    }

    #endregion

    #region Skip

    [Fact]
    public void SkipTest()
    {
        var api = new ApiClientMockup();

        var query = api.Persons.Skip(2);

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Null(api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Equal(2, api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Take clauses. Since we remove the Take clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(3, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    #endregion

    #region Take

    [Fact]
    public void TakeTest()
    {
        var api = new ApiClientMockup();

        var query = api.Persons.Take(3);

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Null(api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Equal(3, api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Take clauses. Since we remove the Take clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(3, persons.Count);
        Assert.Equal(5, persons.Count);
    }
    
    [Fact]
    public void SkipTakeTest()
    {
        var api = new ApiClientMockup();

        var query = api.Persons.Skip(2).Take(3);

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Null(api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Equal(2, api.LastRequest?.Offset);
        Assert.Equal(3, api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Take clauses. Since we remove the Take clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(3, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    [Fact]
    public async void OrderByNestingAsyncTest()
    {
        var api = new ApiClientMockup();

        var query =
            from p in api.Persons
            orderby p.Car.Manufacturer
            select p;

        var persons = await query.ToListAsync();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Null(api.LastRequest?.Filter);
        Assert.Equal("*", api.LastRequest?.Fields);
        Assert.Equal("car.manufacturer", api.LastRequest?.Sort);
        Assert.Equal(5, persons.Count);
    }

    #endregion

    #region Include

    [Fact]
    public void IncludeTest()
    {
        var api = new ApiClientMockup();

        var query = api.Persons
            .Include(p => p.Car);

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Null(api.LastRequest?.Filter);
        Assert.Equal("*,car.*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Take clauses. Since we remove the Take clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(3, persons.Count);
        Assert.Equal(5, persons.Count);
    }
    
    [Fact]
    public void IncludeSecondNestedTest()
    {
        var api = new ApiClientMockup();

        var query = api.Persons
            .Include(p => p.Car.Manufacturer);

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Null(api.LastRequest?.Filter);
        Assert.Equal("*,car.manufacturer.*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Take clauses. Since we remove the Take clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(3, persons.Count);
        Assert.Equal(5, persons.Count);
    }
    
    [Fact]
    public void IncludeThenIncludeTest()
    {
        var api = new ApiClientMockup();

        var query = api.Persons
            .Include(p => p.Car)
                .ThenInclude(c => c.ManufacturerInfo);

        var persons = query.ToList();
        Assert.Equal("persons", api.LastEndpoint);
        Assert.Null(api.LastRequest?.Filter);
        Assert.Equal("*,car.*,car.manufacturerInfo.*", api.LastRequest?.Fields);
        Assert.Null(api.LastRequest?.Sort);
        Assert.Null(api.LastRequest?.Offset);
        Assert.Null(api.LastRequest?.Limit);
        // NOTE: Currently the Mockup API Client does not interpret Take clauses. Since we remove the Take clause
        //       from the expression tree, the result will be still the total count of the mockup data.
        //Assert.Equal(3, persons.Count);
        Assert.Equal(5, persons.Count);
    }

    #endregion
}
