<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
  <xsl:output method="xml" version="1.0" encoding="UTF-8" indent="yes"/>

  <xsl:template match="/">
    <HTML>
      <HEAD>
        <LINK rel="stylesheet" type="text/css" href="spec.css" />
      </HEAD>
      <BODY>
        <xsl:apply-templates select="XMLDocument" />
      </BODY>
    </HTML>
  </xsl:template>
  <!-- output main table with header row -->
  <xsl:template match="XMLDocument">
    <table width="80%" border="1" cellspacing="0" cellpadding="4" align="center">
      <tr class="TableHeader" bgcolor="#000080">
        <td width="25%" align="center" >ProductID</td>
        <td width="25%" align="center" >ProductName</td>
        <td width="25%" align="center" >UnitsInStock</td>
        <td width="25%" align="center" >UnitsOnOrder</td>
      </tr>
      <xsl:apply-templates select="ProductList" />
    </table>
  </xsl:template>

  <!-- output a row in the table for each EmployeeInfo node in the XML document -->
  <xsl:template match="ProductList" >
    <tr class="TableCellNormal" bgcolor="#FFFFE0">
      <td width="25%">
        <xsl:value-of select="ProductID"/>
      </td>
      <td width="25%" align="center">
        <xsl:value-of select="ProductName" />
      </td>
      <td width="25%" align="center">
        <xsl:value-of select="UnitsInStock" />
      </td>
      <td width="25%" align="center">
        <xsl:value-of select="UnitsOnOrder" />
      </td>
    </tr>
  </xsl:template>
</xsl:stylesheet>