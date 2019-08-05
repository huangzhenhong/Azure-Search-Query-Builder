﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Azure.Search.Models;

namespace AzureSearchQueryBuilder.Builders
{
    public class SearchParametersBuilder<TModel> : ParametersBuilder<TModel, SearchParameters>, ISearchParametersBuilder<TModel>
    {
        private IList<string> _facets;
        private IList<string> _highlightFields;
        private IList<string> _orderBy;
        private IList<ScoringParameter> _scoringParameters;
        private IList<string> _select;

        private SearchParametersBuilder()
        {
        }

        public IEnumerable<string> Facets { get => this._facets; }

        public IEnumerable<string> HighlightFields { get => this._highlightFields; }

        public bool IncludeTotalResultCount { get; private set; }

        public IEnumerable<string> OrderBy { get => this._orderBy; }

        public QueryType QueryType { get; private set; }

        public IEnumerable<ScoringParameter> ScoringParameters { get => this._scoringParameters; }

        public string ScoringProfile { get; private set; }

        public SearchMode SearchMode { get; private set; }

        public IEnumerable<string> Select { get => this._select; }

        public int? Skip { get; private set; }

        public static ISearchParametersBuilder<TModel> Create() => new SearchParametersBuilder<TModel>();

        public override SearchParameters Build()
        {
            return new SearchParameters()
            {
                Facets = this.Facets?.ToList(),
                Filter = this.Filter,
                HighlightFields = this.HighlightFields?.ToList(),
                HighlightPostTag = this.HighlightPostTag,
                HighlightPreTag = this.HighlightPreTag,
                IncludeTotalResultCount = this.IncludeTotalResultCount,
                MinimumCoverage = this.MinimumCoverage,
                OrderBy = this.OrderBy?.ToList(),
                QueryType = this.QueryType,
                ScoringParameters = this.ScoringParameters?.ToList(),
                ScoringProfile = this.ScoringProfile,
                SearchFields = this.SearchFields?.ToList(),
                SearchMode = this.SearchMode,
                Select = this.Select?.ToList(),
                Skip = this.Skip,
                Top = this.Top,
            };
        }

        public ISearchParametersBuilder<TModel> WithFacet<TProperty>(Expression<PropertyLambdaDelegate<TModel, TProperty>> lambdaExpression)
        {
            if (lambdaExpression == null) throw new ArgumentNullException(nameof(lambdaExpression));

            if (this._facets == null)
            {
                this._facets = new List<string>();
            }

            throw new NotImplementedException();
        }

        public ISearchParametersBuilder<TModel> WithHighlightField<TProperty>(Expression<PropertyLambdaDelegate<TModel, TProperty>> lambdaExpression)
        {
            if (lambdaExpression == null) throw new ArgumentNullException(nameof(lambdaExpression));

            if (this._highlightFields == null)
            {
                this._highlightFields = new List<string>();
            }

            throw new NotImplementedException();
        }

        public ISearchParametersBuilder<TModel> WithIncludeTotalResultCount(bool includeTotalResultCount)
        {
            this.IncludeTotalResultCount = includeTotalResultCount;
            return this;
        }

        public ISearchParametersBuilder<TModel> WithQueryType(QueryType queryType)
        {
            this.QueryType = queryType;
            return this;
        }

        public ISearchParametersBuilder<TModel> OrderByAscending<TProperty>(Expression<PropertyLambdaDelegate<TModel, TProperty>> lambdaExpression)
        {
            if (lambdaExpression == null) throw new ArgumentNullException(nameof(lambdaExpression));

            this._orderBy = new List<string>();

            throw new NotImplementedException();
        }

        public ISearchParametersBuilder<TModel> OrderByDescending<TProperty>(Expression<PropertyLambdaDelegate<TModel, TProperty>> lambdaExpression)
        {
            if (lambdaExpression == null) throw new ArgumentNullException(nameof(lambdaExpression));

            this._orderBy = new List<string>();

            throw new NotImplementedException();
        }

        public ISearchParametersBuilder<TModel> WithScoringParameter<TProperty>(Expression<PropertyLambdaDelegate<TModel, TProperty>> lambdaExpression)
        {
            if (lambdaExpression == null) throw new ArgumentNullException(nameof(lambdaExpression));

            if (this._scoringParameters == null)
            {
                this._scoringParameters = new List<ScoringParameter>();
            }

            throw new NotImplementedException();
        }

        public ISearchParametersBuilder<TModel> WithScoringProfile(string scoringProfile)
        {
            this.ScoringProfile = scoringProfile;
            return this;
        }

        public ISearchParametersBuilder<TModel> WithSearchMode(SearchMode searchMode)
        {
            this.SearchMode = searchMode;
            return this;
        }

        public ISearchParametersBuilder<TModel> WithSelect<TProperty>(Expression<PropertyLambdaDelegate<TModel, TProperty>> lambdaExpression)
        {
            if (lambdaExpression == null) throw new ArgumentNullException(nameof(lambdaExpression));

            if (this._select == null)
            {
                this._select = new List<string>();
            }

            throw new NotImplementedException();
        }

        public ISearchParametersBuilder<TModel> WithSkip(int? skip)
        {
            this.Skip = skip;
            return this;
        }

        public ISearchParametersBuilder<TModel> ThenByAscending<TProperty>(Expression<PropertyLambdaDelegate<TModel, TProperty>> lambdaExpression)
        {
            if (lambdaExpression == null) throw new ArgumentNullException(nameof(lambdaExpression));
            if (this._orderBy == null || this._orderBy.Count < 1) throw new Exception();

            throw new NotImplementedException();
        }

        public ISearchParametersBuilder<TModel> ThenByDescending<TProperty>(Expression<PropertyLambdaDelegate<TModel, TProperty>> lambdaExpression)
        {
            if (lambdaExpression == null) throw new ArgumentNullException(nameof(lambdaExpression));
            if (this._orderBy == null || this._orderBy.Count < 1) throw new Exception();

            throw new NotImplementedException();
        }
    }
}