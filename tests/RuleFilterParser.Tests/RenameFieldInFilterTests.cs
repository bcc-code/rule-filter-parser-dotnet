﻿using RuleFilterParser;

namespace RuleToLinqParser.Tests;

public class RenameFieldInFilterTests
{
    [Fact]
    public void should_rename_field_filter()
    {
        var filter = new Filter("{\"test1\":{\"_eq\":\"lorem\"},\"test2\":{\"_eq\":\"ipsum\"}}");
        var expected = new Filter("{\"test100\":{\"_eq\":\"lorem\"},\"test2\":{\"_eq\":\"ipsum\"}}");
        filter.RenameFieldInFilter("test1", "test100");

        Assert.True(expected.Properties.Keys.SequenceEqual(filter.Properties.Keys));
    }

    [Fact]
    public void should_rename_field_filter_nested_in_another_field_filter()
    {
        var filter = new Filter("{\"test1\":{\"test2\":{\"_eq\":\"ipsum\"}}}");
        var expected = new Filter("{\"test1\":{\"test100\":{\"_eq\":\"ipsum\"}}}");
        filter.RenameFieldInFilter("test2", "test100");

        Assert.True(
            (expected.Properties["test1"] as Filter).Properties.Keys.SequenceEqual(
                (filter.Properties["test1"] as Filter).Properties.Keys));
    }

    [Fact]
    public void should_rename_field_filter_nested_in_logical_operator()
    {
        var filter = new Filter("{\"_and\":[{\"test2\":{\"_eq\":\"xyz\"}}]}");
        var expected = new Filter("{\"_and\":[{\"test100\":{\"_eq\":\"xyz\"}}]}");
        filter.RenameFieldInFilter("test2", "test100");

        Assert.True(
            (expected.Properties["_and"] as Filter).Properties.Keys.SequenceEqual(
                (filter.Properties["_and"] as Filter).Properties.Keys));

    }
}