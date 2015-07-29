<?xml version="1.0" encoding="UTF-8"?>
	<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform">
	<xsl:template match="/">
		<HTML>
			<HEAD>
				<LINK rel="stylesheet" type="text/css" href="spec.css" />
			</HEAD>
			<BODY>
				<xsl:apply-templates select="coursespec" />
			</BODY>
		</HTML>
	</xsl:template>
	
	<xsl:template match="coursespec">
  		<TABLE width="653">
    		<TR> 
      			<TD width="100"></TD>
      			<TD width="553"><H3>Course Specification:</H3></TD>
    		</TR>
    		<TR> 
      			<TD width="100"></TD>
      			<TD width="553"><H1><xsl:value-of select="title/text()" /></H1></TD>
    		</TR>
    		<TR>    
    			<TD width="100"></TD>
    			<TD width="553"><H6><xsl:value-of select="codeandversion/text()" /></H6></TD>
    		</TR>
   		</TABLE>
  		<TABLE>
  			<TR> 
    			<TD width="315"><H2>Objectives:</H2></TD>
    			<TD width="23"></TD>
    			<TD width="315"><H2>Pre-Requisites:</H2></TD>
  			</TR>
  			<TR> 
    			<TD width="315" valign="top">
    				<P><xsl:value-of select="objectives/text()" /></P>
    			</TD>
    			<TD width="23"></TD>
    			<TD width="315"  valign="top">
    				<P><xsl:value-of select="prerequisits/text()" /></P>
    				<UL>
      					<LI>
       						<A>
      							<xsl:attribute name="href">
      								<xsl:value-of select="links/relatedcourses/text()" />
      							</xsl:attribute>
      							View List of Related Courses
      						</A>
						</LI>
     					<LI><A href="booking.htm">Online Booking</A></LI>
      					<LI>
      						<A>
      							<xsl:attribute name="href">
      								<xsl:value-of select="links/pdfformat/text()" />
      							</xsl:attribute>
      							PDF Format of this document
      						</A>
      					</LI>
    				</UL>
    			</TD>
  			</TR>
  			<TR> 
    			<TD width="315"><H2>Course Outline:</H2></TD>
    			<TD width="23"></TD>
    			<TD width="315"></TD>
  			</TR>
  			<TR> 
    			<TD width="315" valign="top">
    				<UL>
 						<xsl:for-each select="firstrowdetails/topicheading">
        					<LI>
        						<B><xsl:value-of select="text()" /></B><BR />
        						<xsl:value-of select="../topicdetails/text()" />
 							</LI>
 						</xsl:for-each>
    				</UL>
    			</TD>
    			<TD width="23"></TD>
    			<TD width="315" valign="top">
      				<UL>
 						<xsl:for-each select="secondrowdetails/topicheading">
        					<LI>
        						<B><xsl:value-of select="text()" /></B><BR />
        						<xsl:value-of select="../topicdetails/text()" />
 							</LI>
 						</xsl:for-each>
      				</UL>
    			</TD>
  			</TR>
		</TABLE>
	</xsl:template>
	</xsl:stylesheet>
	