<?xml version="1.0" encoding="iso-8859-1"?>
<xsl:stylesheet version="1.0"
xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:template match="Root">
    <html>
      <head>
        <title>Coverage Result</title>
        <link rel="stylesheet" href="StyleSheet.css" />
      </head>
      <body>
        <xsl:variable name="CoveredStatements" select="@CoveredStatements" />
        <xsl:variable name="TotalStatements" select="@TotalStatements" />
        <xsl:variable name="CoveragePercent" select="@CoveragePercent" />

        <table width="100%">
          <tr>
            <th width="55%"></th>
            <th width="15%" style="color:#0033CC;">TotalStatements</th>
            <th width="15%" style="color:#33CC33;">CoveredStatements</th>
            <th width="15%" style="color:#FF9900;">CoveragePercent</th>
          </tr>
          <tr>
            <th></th>
            <td ALIGN="center" style="color:#0033CC;">
              <xsl:value-of select="$TotalStatements" />
            </td>
            <td ALIGN="center" style="color:#33CC33;">
              <xsl:value-of select="$CoveredStatements" />
            </td>

            <td ALIGN="center" style="color:#FF9900;">
              <xsl:value-of select="$CoveragePercent" />
            </td>
          </tr>
        </table>
        <xsl:for-each select="Assembly">
          <br />
          <xsl:for-each select="Namespace">
            <table width="100%">
              <tr>
                <th width="55%">Namespace</th>
                <th width="15%" style="color:#0033CC;">Total Statements</th>
                <th width="15%" style="color:#33CC33;">Covered Statements</th>
                <th width="15%" style="color:#FF9900;">Cover Percentage</th>
              </tr>
              <tr>
                <td ALIGN="left">
                  <xsl:variable name="namespace_bookmark" select="@Name" />
                  <xsl:value-of select="$namespace_bookmark" />
                </td>
                <td ALIGN="center" style="color:#0033CC;">
                  <xsl:value-of select="@TotalStatements" />
                </td>
                <td ALIGN="center" style="color:#33CC33;">
                  <xsl:value-of select="@CoveredStatements" />
                </td>
                <td ALIGN="center" style="color:#FF9900;">
                  <xsl:value-of select="@CoveragePercent" />%
                </td>
              </tr>
              <tr>
                <td colspane="4"></td>
              </tr>
              <xsl:for-each select="Type">
                <tr>
                  <td ALIGN="left" class="padded" style="color:#ccc;">
                    <xsl:variable name="type_bookmark" select="@Name" />
                    <xsl:value-of select="$type_bookmark" />
                  </td>
                  <td ALIGN="center" style="color:#0033CC;">
                    <xsl:value-of select="@TotalStatements" />
                  </td>
                  <td ALIGN="center" style="color:#33CC33;">
                    <xsl:value-of select="@CoveredStatements" />
                  </td>
                  <td ALIGN="center" style="color:#FF9900;">
                    <xsl:value-of select="@CoveragePercent" />%
                  </td>
                </tr>
              </xsl:for-each>
              <xsl:for-each select="Member">
                <tr>
                  <td ALIGN="center" style="color:#0033CC;">
                    <xsl:variable name="member_bookmark" select="@Name" />
                    <xsl:value-of select="$member_bookmark" />
                  </td>
                  <td ALIGN="center" style="color:#0033CC;">
                    <xsl:value-of select="@TotalStatements" />
                  </td>
                  <td ALIGN="center" style="color:#FF9900;">
                    <xsl:value-of select="@CoveredStatements" />
                  </td>
                  <td ALIGN="center" style="color:#0033CC;">
                    <xsl:value-of select="@CoveragePercent" />%
                  </td>
                </tr>
              </xsl:for-each>
            </table>
            <br />
          </xsl:for-each>
        </xsl:for-each>
        <p>
          <p>
            <h3>Legend</h3>
            <table>
              <tr>
                <td class="legend_total_statements">.....</td>
                <td ALIGN="center">Total Statements</td>
              </tr>
              <tr>
                <td class="legend_covered_statements">.....</td>
                <td ALIGN="center">Covered Statements</td>
              </tr>
              <tr>
                <td class="legend_covered_percentage">.....</td>
                <td ALIGN="center">Covered Percentage</td>
              </tr>
            </table>
          </p>
        </p>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
