<?xml version="1.0" encoding="UTF-8"?>
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




-----------------

Help with XSLT for following XML
<gp>
<p>
<c>
<gc>
<name>fsrst</name>
<ad>1adr</ad>
</gc>
<gc>
<name>sec</name>
<ad>2ad</ad>
</gc>

</c>
</p>
</gp>

which should return xml as below
<answerset>
<Tbl name="gc_1">
<r>
<col>fsrst</col>
<col>1adr</col>
</r>
</Tbl>
<Tbl name="gc_2">
<r>
<col>sec</col>
<col>2ad</col>
</r>
</Tbl>

</answer>
</answerset>
<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">
    <xsl:output method="xml" indent="yes"/>
    
    <!-- Root template matching the 'gp' element -->
    <xsl:template match="gp">
        <answerset>
            <!-- Apply templates to all 'gc' elements and pass the position for dynamic name generation -->
            <xsl:apply-templates select=".//gc" />
        </answerset>
    </xsl:template>

    <!-- Template that matches each 'gc' element -->
    <xsl:template match="gc">
        <!-- Generate a Tbl element with a dynamic name using the position of the 'gc' element -->
        <Tbl name="gc_{position()}">
            <r>
                <!-- First column contains the value of the 'name' element -->
                <col>
                    <xsl:value-of select="name"/>
                </col>
                <!-- Second column contains the value of the 'ad' element -->
                <col>
                    <xsl:value-of select="ad"/>
                </col>
            </r>
        </Tbl>
    </xsl:template>
</xsl:stylesheet>


---------------------- get path as attribute

<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform" version="1.0">

  <!-- Match the root and begin constructing the <answerset> -->
  <xsl:template match="/">
    <answerset>
      <!-- Apply template for the specific path 'al/l3/value' -->
      <xsl:apply-templates select="/al/l3/value"/>
    </answerset>
  </xsl:template>

  <!-- Template to match the <value> under the <l3> element -->
  <xsl:template match="al/l3/value">
    <answer name="{name(..)}" path="{generate-path(.)}">
      <!-- Output the value of <value> element wrapped in <Tv> -->
      <Tv>
        <xsl:value-of select="."/>
      </Tv>
    </answer>
  </xsl:template>

  <!-- Recursive template to generate the path -->
  <xsl:template name="generate-path">
    <xsl:param name="current-node" select="."/>
    <xsl:choose>
      <xsl:when test="not(parent::*)">
        <xsl:value-of select="name($current-node)"/>
      </xsl:when>
      <xsl:otherwise>
        <xsl:value-of select="concat(name($current-node), '\', '')"/>
        <xsl:call-template name="generate-path">
          <xsl:with-param name="current-node" select="parent::*"/>
        </xsl:call-template>
      </xsl:otherwise>
    </xsl:choose>
  </xsl:template>

</xsl:stylesheet>
