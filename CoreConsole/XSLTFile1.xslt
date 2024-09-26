﻿<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <!-- Match the root element dateP -->
  <xsl:template match="/dateP">
    <!-- Output month/day/year format -->
    <xsl:value-of select="m"/>
    <xsl:text>/</xsl:text>
    <xsl:value-of select="d"/>
    <xsl:text>/</xsl:text>
    <xsl:value-of select="y"/>
  </xsl:template>
</xsl:stylesheet>

<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
  <!-- Match the root element al -->
  <xsl:template match="/al">
    <!-- Iterate over all child elements of al -->
    <xsl:for-each select="*">
      <xsl:value-of select="."/>
      <!-- Add a space between the values -->
      <xsl:if test="position() != last()">
        <xsl:text> </xsl:text>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>
</xsl:stylesheet>

<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

  <!-- Match the root element <al> -->
  <xsl:template match="/al">
    <!-- Iterate over all child elements -->
    <xsl:for-each select="*[starts-with(name(), 'l')]">
      <xsl:value-of select="."/>
      <!-- Add a space between values -->
      <xsl:if test="position() != last()">
        <xsl:text> </xsl:text>
      </xsl:if>
    </xsl:for-each>
  </xsl:template>

</xsl:stylesheet>

<!--Explanation:
The match="/al" template matches the root <al>
  element.
  The xsl:for-each selects all child elements of <al>
    .
    The xsl:value-of select="." outputs the text content of each child element.
    The xsl:if ensures a space is added between the values, except after the last element.-->
    <!--<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
    <xsl:output method="xml" indent="yes"/>

    <xsl:template match="@* | node()">
        <xsl:copy>
            <xsl:apply-templates select="@* | node()"/>
        </xsl:copy>
    </xsl:template>
</xsl:stylesheet>-->

<gp>
    <p>
        <c>
            <gc>grandchild</gc>
        </c>
    </p>
</gp>
<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:output method="xml" indent="yes"/>

    <!-- Root template that matches the 'gp' element -->
    <xsl:template match="gp">
        <answerset>
            <!-- Apply templates to any 'gc' element -->
            <xsl:apply-templates select=".//gc"/>
        </answerset>
    </xsl:template>

    <!-- Template that matches the 'gc' element -->
    <xsl:template match="gc">
        <answer name="{name()}"> <!-- Add the 'name' attribute with the element name 'gc' -->
            <tv>
                <!-- Output the value of the 'gc' element -->
                <xsl:value-of select="."/>
            </tv>
        </answer>
    </xsl:template>

</xsl:stylesheet>