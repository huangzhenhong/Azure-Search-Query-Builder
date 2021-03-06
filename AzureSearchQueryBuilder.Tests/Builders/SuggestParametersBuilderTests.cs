using System.Linq;
using AzureSearchQueryBuilder.Builders;
using Microsoft.Azure.Search.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AzureSearchQueryBuilder.Tests.Builders
{
    [TestClass]
    public class SuggestParametersBuilderTests : ParametersBuilderTests<SuggestParameters>
    {
        [TestMethod]
        public void SearchPropertyNameUtility_OrderBy()
        {
            ISuggestParametersBuilder<Model> suggestParametersBuilder = SuggestParametersBuilder<Model>.Create();

            Assert.IsNull(suggestParametersBuilder.OrderBy);

            suggestParametersBuilder.WithOrderBy(_ => SearchFns.Score()).WithThenByDescending(_ => SearchFns.Score());

            Assert.IsNotNull(suggestParametersBuilder.OrderBy);
            Assert.AreEqual(2, suggestParametersBuilder.OrderBy.Count());
            Assert.AreEqual("search.score() asc", suggestParametersBuilder.OrderBy.ElementAtOrDefault(0));
            Assert.AreEqual("search.score() desc", suggestParametersBuilder.OrderBy.ElementAtOrDefault(1));

            SuggestParameters parameters = suggestParametersBuilder.Build();
            Assert.IsNotNull(parameters);
            Assert.IsNotNull(parameters.OrderBy);
            Assert.AreEqual(2, parameters.OrderBy.Count());
            Assert.AreEqual("search.score() asc", parameters.OrderBy.ElementAtOrDefault(0));
            Assert.AreEqual("search.score() desc", parameters.OrderBy.ElementAtOrDefault(1));

            suggestParametersBuilder.WithOrderByDescending(_ => SearchFns.Score()).WithThenBy(_ => SearchFns.Score());

            Assert.IsNotNull(suggestParametersBuilder.OrderBy);
            Assert.AreEqual(2, suggestParametersBuilder.OrderBy.Count());
            Assert.AreEqual("search.score() desc", suggestParametersBuilder.OrderBy.ElementAtOrDefault(0));
            Assert.AreEqual("search.score() asc", suggestParametersBuilder.OrderBy.ElementAtOrDefault(1));

            parameters = suggestParametersBuilder.Build();
            Assert.IsNotNull(parameters);
            Assert.IsNotNull(parameters.OrderBy);
            Assert.AreEqual(2, parameters.OrderBy.Count());
            Assert.AreEqual("search.score() desc", parameters.OrderBy.ElementAtOrDefault(0));
            Assert.AreEqual("search.score() asc", parameters.OrderBy.ElementAtOrDefault(1));
        }

        [TestMethod]
        public void SearchPropertyNameUtility_Select()
        {
            ISuggestParametersBuilder<Model> suggestParametersBuilder = SuggestParametersBuilder<Model>.Create();

            Assert.IsNull(suggestParametersBuilder.Select);

            suggestParametersBuilder.WithSelect(_ => SearchFns.Score());

            Assert.IsNotNull(suggestParametersBuilder.Select);
            Assert.AreEqual(1, suggestParametersBuilder.Select.Count());
            Assert.AreEqual("search.score()", suggestParametersBuilder.Select.ElementAtOrDefault(0));

            SuggestParameters parameters = suggestParametersBuilder.Build();
            Assert.IsNotNull(parameters);
            Assert.IsNotNull(parameters.Select);
            Assert.AreEqual(1, parameters.Select.Count());
            Assert.AreEqual("search.score()", parameters.Select.ElementAtOrDefault(0));
        }

        [TestMethod]
        public void SuggestPropertyNameUtility_UseFuzzyMatching()
        {
            ISuggestParametersBuilder<Model> suggestParametersBuilder = SuggestParametersBuilder<Model>.Create();

            Assert.IsFalse(suggestParametersBuilder.UseFuzzyMatching);

            suggestParametersBuilder.WithUseFuzzyMatching(true);

            Assert.IsNotNull(suggestParametersBuilder.UseFuzzyMatching);
            Assert.IsTrue(suggestParametersBuilder.UseFuzzyMatching);

            SuggestParameters parameters = suggestParametersBuilder.Build();
            Assert.IsNotNull(parameters);
            Assert.IsTrue(parameters.UseFuzzyMatching);
        }

        protected override IParametersBuilder<Model, SuggestParameters> ConstructBuilder()
        {
            return (SuggestParametersBuilder<Model>)SuggestParametersBuilder<Model>.Create();
        }
    }
}
