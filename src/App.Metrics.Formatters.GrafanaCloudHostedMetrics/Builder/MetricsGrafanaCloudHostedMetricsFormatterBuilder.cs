﻿// <copyright file="MetricsGrafanaCloudHostedMetricsFormatterBuilder.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System;
using App.Metrics.Formatters.GrafanaCloudHostedMetrics;

// ReSharper disable CheckNamespace
namespace App.Metrics
    // ReSharper restore CheckNamespace
{
    public static class MetricsGrafanaCloudHostedMetricsFormatterBuilder
    {
        /// <summary>
        ///     Add the <see cref="MetricsHostedMetricsJsonOutputFormatter" /> allowing metrics to optionally be reported to
        ///     GrafanaCloud Hosted Metrics Graphite syntax.
        /// </summary>
        /// <param name="metricFormattingBuilder">s
        ///     The <see cref="IMetricsOutputFormattingBuilder" /> used to configure GrafanaCloud Hosted Metrics formatting
        ///     options.
        /// </param>
        /// <param name="setupAction">The GrafanaCloud Hosted Metrics formatting options to use.</param>
        /// <returns>
        ///     An <see cref="IMetricsBuilder" /> that can be used to further configure App Metrics.
        /// </returns>
        public static IMetricsBuilder AsGrafanaCloudHostedMetricsGraphiteSyntax(
            this IMetricsOutputFormattingBuilder metricFormattingBuilder,
            Action<MetricsHostedMetricsOptions> setupAction)
        {
            if (metricFormattingBuilder == null)
            {
                throw new ArgumentNullException(nameof(metricFormattingBuilder));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            var options = new MetricsHostedMetricsOptions();

            setupAction.Invoke(options);

            var formatter = new MetricsHostedMetricsJsonOutputFormatter(options);

            return metricFormattingBuilder.Using(formatter, false);
        }

        /// <summary>
        ///     Add the <see cref="MetricsHostedMetricsJsonOutputFormatter" /> allowing metrics to optionally be reported to
        ///     GrafanaCloud Hosted Metrics Graphite syntax.
        /// </summary>
        /// <param name="metricFormattingBuilder">s
        ///     The <see cref="IMetricsOutputFormattingBuilder" /> used to configure GrafanaCloud Hosted Metrics formatting
        ///     options.
        /// </param>
        /// <returns>
        ///     An <see cref="IMetricsBuilder" /> that can be used to further configure App Metrics.
        /// </returns>
        public static IMetricsBuilder AsGrafanaCloudHostedMetricsGraphiteSyntax(this IMetricsOutputFormattingBuilder metricFormattingBuilder)
        {
            if (metricFormattingBuilder == null)
            {
                throw new ArgumentNullException(nameof(metricFormattingBuilder));
            }

            var formatter = new MetricsHostedMetricsJsonOutputFormatter();

            return metricFormattingBuilder.Using(formatter, false);
        }
    }
}