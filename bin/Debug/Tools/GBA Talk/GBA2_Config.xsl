<?xml version="1.0" ?>
<!-- This is a style sheet to display a GBA2 Config File -->
<!-- Updated 12/apr/2011: added note thickness parameter -->
<!-- Updated 02/jan/2013: added dump note at power up and MDB single events -->
<!-- Updated 28/oct/2015: added ST1C DIP Switch -->
<xsl:stylesheet 
	xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
	version='1.0'>

	<xsl:template match="text()">
		<xsl:value-of select="." />
	</xsl:template>
	<xsl:template match="/">
		<HTML>
			<HEAD>
				<META http-equiv="Content-Language" content="en-uk" />
				<META http-equiv="Content-Type" content="text/html; charset=windows-1252" />
				<META name="AUTHOR" content="Steve Lewis" />
				<TITLE>
					<xsl:value-of select="GBA_Configuration/Title" />
				</TITLE>
			</HEAD>
			<BODY>
				<H1>
					<xsl:value-of select="GBA_Configuration/Title" />
				</H1>
				<HR />
				<!-- First Table holds the modle and currency details -->
				<TABLE border="1" width="600">
					<FONT size="2">
						<!-- 1stRow is the model -->
						<TR>
							<TD width="33%">
								Model Type
							</TD>
							<TD width="67%">
								<xsl:value-of select="GBA_Configuration/Model" />
							</TD>
						</TR>
						<!-- 2nd Row is the currency code -->
						<TR>
							<TD>Currency Code</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/Currency/Currency_Code" />
							</TD>
						</TR>
						<!-- 2.5th Row is the country name -->
						<TR>
							<TD>Country Name</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/Currency/Country_Name" />
							</TD>
						</TR>
						<!-- 2.6th Row is the config code -->
						<TR>
							<TD>Config Reference</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/Config_Code" />
							</TD>
						</TR>
						<!-- 3rd Row is the firmware -->
						<TR>
							<TD>Firmware Revision</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/Currency/Firmware" />
							</TD>
						</TR>
						<!-- 3rd Row is the firmware -->
						<TR>
							<TD>Firmware Revision (S12X)</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/Currency/FirmwareX" />
							</TD>
						</TR>
						<!-- 4th Row is the Software -->
						<TR>
							<TD>Note Dataset Revision</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/Currency/Software" />
							</TD>
						</TR>
						<!-- 5th Row is the Date-->
						<TR>
							<TD>Date Last Modified</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/Currency/Date" />
							</TD>
						</TR>
						<!-- 6th Row are the Application-->
						<TR>
							<TD>Application</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/Currency/Application" />
							</TD>
						</TR>
						<!-- 7th Row are the Comments-->
						<TR>
							<TD>Comments</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/Currency/Comments" />
							</TD>
						</TR>
						<!-- 8th Row is the details of the dataset revision used to create this-->
						<TR>
							<TD>Based on dataset</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/Currency/Data_Revn" />
							</TD>
						</TR>
					</FONT>
				</TABLE>
				<!-- Next Table Shows the note data -->
				<HR />
				<H2> Note Settings</H2>
				<TABLE border="1" width="600">
					<FONT size="2">
						<!-- 1stRow is the headings-->
						<TR>
							<TH width="10%">Note No.</TH>
							<TH width="40%">Note Type</TH>
							<TH width="20%">Enabled</TH>
							<TH width="20%">Security</TH>
						</TR>
						<!-- Now fill in note details for each note present -->
						<xsl:for-each select="GBA_Configuration/Note">
						  <xsl:if test="Description[.!='VOID']">
							<TR>
							  <TD>
								<xsl:value-of select="@ID" />
							  </TD>
							  <TD>
								<xsl:value-of select="Description" />
							  </TD>
							  <TD>
								<xsl:value-of select="Enabled" />
							  </TD>
							  <TD>
								<xsl:choose>
								  <xsl:when test="Security[.='0']">Low</xsl:when>
								  <xsl:when test="Security[.='1']">Standard</xsl:when>
								  <xsl:when test="Security[.='2']">High</xsl:when>
								  <xsl:when test="Security[.='3']">Highest</xsl:when>
								  <xsl:when test="Security[.='128']">Low (Mag)</xsl:when>
								  <xsl:when test="Security[.='129']">Standard (Mag)</xsl:when>
								  <xsl:when test="Security[.='130']">High (Mag)</xsl:when>
								  <xsl:when test="Security[.='131']">Highest (Mag)</xsl:when>
								</xsl:choose>
							  </TD>
							</TR>
						  </xsl:if>
						</xsl:for-each>
					</FONT>
				</TABLE>
				<!-- Next Table Shows the interface data -->
				<HR />
				<H2> Interface Data </H2>
				<TABLE border="1" width="400">
					<FONT size="2">
						<TR>
							<TD width="60%">Interface Name</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/Interface/Description" />
							</TD>
						</TR>
            <!-- SL 08/feb/12: this alarm now applies to all interfaces -->
            <xsl:if test="GBA_Configuration/Interface/Note_Left_Alarm_Signal[.!='']">
              <TR>
                <TD>Alarm if Note Abandoned</TD>
                <TD>
                  <xsl:choose>
                    <xsl:when test="GBA_Configuration/Interface/Note_Left_Alarm_Signal[.='True']">ON</xsl:when>
                    <xsl:otherwise >OFF</xsl:otherwise>
                  </xsl:choose>
                </TD>
              </TR>
            </xsl:if>
            <xsl:choose>
							<!-- Pulse/Mars Mode -->
							<xsl:when test="GBA_Configuration/Interface/@ID[.='0']">
								<TR>
									<TD>Pulses/Unit</TD>
									<TD>
										<xsl:value-of select="GBA_Configuration/Interface/Pulses_Unit" />
									</TD>
								</TR>
								<TR>
									<TD>Pulses Width</TD>
									<TD><xsl:value-of select="GBA_Configuration/Interface/Pulse_Width" /> msec</TD>
								</TR>
								<TR>
									<TD>Gap Width</TD>
									<TD><xsl:value-of select="GBA_Configuration/Interface/Gap_Width" /> msecs</TD>
								</TR>
                <xsl:if test="GBA_Configuration/Model[.='GBA HR1']">
                  <TR>
									  <TD>Use Stella Mode</TD>
									  <TD>
										  <xsl:value-of select="GBA_Configuration/Interface/Extended_Mode" />
									  </TD>
								  </TR>
                </xsl:if>  
                <xsl:if test="GBA_Configuration/Model[.!='GBA HR1']">
                  <TR>
									  <TD>Ignore Inhibit Line?</TD>
									  <TD>
                      <xsl:choose>
                        <xsl:when test="GBA_Configuration/Interface/Ignore_Inhibit[.='True']">IGNORE</xsl:when>
                        <xsl:otherwise >USED</xsl:otherwise>
                      </xsl:choose>
                    </TD>
								  </TR>
                  <TR>
									  <TD>Enable Line Active High?</TD>
									  <TD>
                      <xsl:choose>
                        <xsl:when test="GBA_Configuration/Interface/Enable_High[.='True']">HIGH</xsl:when>
                        <xsl:otherwise >LOW</xsl:otherwise>
                      </xsl:choose>
                    </TD>
								  </TR>
                </xsl:if>  
                <xsl:if test="GBA_Configuration/Interface/Escrow_Timeout[.!='']">
                  <TR>
                    <TD>Mars Serial Timeout</TD>
                    <TD>
                      <xsl:value-of select="GBA_Configuration/Interface/Escrow_Timeout" /> secs
                    </TD>
                  </TR>
                </xsl:if>
              </xsl:when>
							<!-- Parallel Mode -->
							<xsl:when test="GBA_Configuration/Interface/@ID[.='1']">
								<TR>
									<TD>Escrow Timeout</TD>
									<TD><xsl:value-of select="GBA_Configuration/Interface/Escrow_Timeout" /> secs</TD>
								</TR>
								<TR>
									<TD>Extended Alarm Signal</TD>
									<TD>
										<xsl:value-of select="GBA_Configuration/Interface/Extended_Alarm_Signal" />
									</TD>
								</TR>
                <xsl:if test="GBA_Configuration/Model[.!='GBA HR1']">
                  <TR>
                    <TD>Ignore Inhibit Line?</TD>
                    <TD>
                      <xsl:choose>
                        <xsl:when test="GBA_Configuration/Interface/Ignore_Inhibit[.='True']">IGNORE</xsl:when>
                        <xsl:otherwise >USED</xsl:otherwise>
                      </xsl:choose>
                    </TD>
                  </TR>
                  <TR>
                    <TD>Enable Line Active High?</TD>
                    <TD>
                      <xsl:choose>
                        <xsl:when test="GBA_Configuration/Interface/Enable_High[.='True']">HIGH</xsl:when>
                        <xsl:otherwise >LOW</xsl:otherwise>
                      </xsl:choose>
                    </TD>
                  </TR>
                </xsl:if>
              </xsl:when>
              
							<!-- BSCP Mode -->
							<xsl:when test="GBA_Configuration/Interface/@ID[.='2']">
                <TR>
                  <TD>Timeout Period</TD>
                  <TD><xsl:value-of select="GBA_Configuration/Interface/BSCP_Timeout" />0 msecs</TD>
                </TR>
                <TR>
									<TD>Use Single Note Escrow</TD>
									<TD><xsl:value-of select="GBA_Configuration/Interface/Single_Note_Escrow" /></TD>
								</TR>
							</xsl:when>
              
							<!-- MDB Mode -->
							<xsl:when test="GBA_Configuration/Interface/@ID[.='3']">
                <TR>
                  <TD>Use CCode Dialect</TD>
                  <TD>
                    <xsl:choose>
                      <xsl:when test="GBA_Configuration/Interface/MDB_Ccode[.='True']">ON</xsl:when>
                      <xsl:otherwise >OFF</xsl:otherwise>
                    </xsl:choose>
                  </TD>
                </TR>
                <TR>
                  <TD>Send Events Singly</TD>
                  <TD>
                    <xsl:choose>
                      <xsl:when test="GBA_Configuration/Interface/MDB_Single[.='True']">ON</xsl:when>
                      <xsl:otherwise >OFF</xsl:otherwise>
                    </xsl:choose>
                  </TD>
                </TR>
                <TR>
                  <TD>Amalgamate Denominations</TD>
                  <TD>
                    <xsl:choose>
                      <xsl:when test="GBA_Configuration/Interface/MDB_Amlg[.='True']">ON</xsl:when>
                      <xsl:otherwise >OFF</xsl:otherwise>
                    </xsl:choose>
                  </TD>
                </TR>
                <xsl:if test="GBA_Configuration/Model[.='GBA_ST1C']">
                  <TR>
                    <TD>Lock Interface to Hardware</TD>
                    <TD>
                      <xsl:choose>
                        <xsl:when test="GBA_Configuration/Interface/MDB_Lock[.='True']">ON</xsl:when>
                        <xsl:otherwise >OFF</xsl:otherwise>
                      </xsl:choose>
                    </TD>
                  </TR>
                </xsl:if>
              </xsl:when>
              
							<!-- ccTalk Mode -->
							<xsl:when test="GBA_Configuration/Interface/@ID[.='4'] or GBA_Configuration/Interface/@ID[.='5']">
								<TR>
									<TD>ccTalk ID</TD>
									<TD><xsl:value-of select="GBA_Configuration/Interface/ccTalk_ID" /></TD>
								</TR>
								<TR>
									<TD>Timeout Period</TD>
									<TD><xsl:value-of select="GBA_Configuration/Interface/ccTalk_Timeout" />0 msecs</TD>
								</TR>
								<TR>
									<TD>Checksum Option</TD>
                  <TD>
                    <xsl:choose>
                      <xsl:when test="GBA_Configuration/Interface/ccTalk_Chksm[.='1']">8-Bit</xsl:when>
                      <xsl:otherwise >16-Bit</xsl:otherwise>
                    </xsl:choose>
                  </TD>
                </TR>
                <xsl:if test="GBA_Configuration/Model[.='GBA HR1']">
								  <TR>
									  <TD>Mag Head Option</TD>
									  <TD>
										  <xsl:choose>
											  <xsl:when test="GBA_Configuration/Interface/ccTalk_Mag_Option[.='48']">None</xsl:when>
											  <xsl:when test="GBA_Configuration/Interface/ccTalk_Mag_Option[.='49']">Left</xsl:when>
											  <xsl:when test="GBA_Configuration/Interface/ccTalk_Mag_Option[.='50']">Centre</xsl:when>
											  <xsl:when test="GBA_Configuration/Interface/ccTalk_Mag_Option[.='51']">Right</xsl:when>
										  </xsl:choose>
									  </TD>
								  </TR>
                  </xsl:if>  
								<TR>
									<TD>Use Single Note Escrow</TD>
									<TD><xsl:value-of select="GBA_Configuration/Interface/Single_Note_Escrow" /></TD>
								</TR>
							</xsl:when>
							<!-- Parallel XT Mode -->
							<xsl:when test="GBA_Configuration/Interface/@ID[.='6']">
								<TR>
									<TD>Escrow Timeout</TD>
									<TD><xsl:value-of select="GBA_Configuration/Interface/Escrow_Timeout" /> secs</TD>
								</TR>
								<TR>
									<TD>Extended Alarm Signal</TD>
									<TD>
										<xsl:value-of select="GBA_Configuration/Interface/Extended_Alarm_Signal" />
									</TD>
								</TR>
                <xsl:if test="GBA_Configuration/Model[.!='GBA HR1']">
                  <TR>
                    <TD>Ignore Inhibit Line?</TD>
                    <TD>
                      <xsl:choose>
                        <xsl:when test="GBA_Configuration/Interface/Ignore_Inhibit[.='True']">IGNORE</xsl:when>
                        <xsl:otherwise >USED</xsl:otherwise>
                      </xsl:choose>
                    </TD>
                  </TR>
                  <TR>
                    <TD>Enable Line Active High?</TD>
                    <TD>
                      <xsl:choose>
                        <xsl:when test="GBA_Configuration/Interface/Enable_High[.='True']">HIGH</xsl:when>
                        <xsl:otherwise >LOW</xsl:otherwise>
                      </xsl:choose>
                    </TD>
                  </TR>
                </xsl:if>
              </xsl:when>
							<!-- Parallel Binary Mode -->
							<xsl:when test="GBA_Configuration/Interface/@ID[.='8']">
								<TR>
									<TD>Escrow Timeout</TD>
									<TD><xsl:value-of select="GBA_Configuration/Interface/Escrow_Timeout" /> secs</TD>
								</TR>
								<TR>
									<TD>Send Data Valid Pulse</TD>
									<TD>
										<xsl:value-of select="GBA_Configuration/Interface/Data_Valid_Pulse" />
									</TD>
								</TR>
								<TR>
									<TD>Extended Alarm Signal</TD>
									<TD>
										<xsl:value-of select="GBA_Configuration/Interface/Extended_Alarm_Signal" />
									</TD>
								</TR>
                <xsl:if test="GBA_Configuration/Model[.!='GBA HR1']">
                  <TR>
                    <TD>Ignore Inhibit Line?</TD>
                    <TD>
                      <xsl:choose>
                        <xsl:when test="GBA_Configuration/Interface/Ignore_Inhibit[.='True']">IGNORE</xsl:when>
                        <xsl:otherwise >USED</xsl:otherwise>
                      </xsl:choose>
                    </TD>
                  </TR>
                  <TR>
                    <TD>Enable Line Active High?</TD>
                    <TD>
                      <xsl:choose>
                        <xsl:when test="GBA_Configuration/Interface/Enable_High[.='True']">HIGH</xsl:when>
                        <xsl:otherwise >LOW</xsl:otherwise>
                      </xsl:choose>
                    </TD>
                  </TR>
                </xsl:if>
              </xsl:when>
							<!-- SSP Mode -->
							<xsl:when test="GBA_Configuration/Interface/@ID[.='9']">
								<TR>
									<TD>SSP ID</TD>
									<TD>
										<xsl:value-of select="GBA_Configuration/Interface/SSP_ID" />
									</TD>
								</TR>
								<TR>
									<TD>Timeout Period</TD>
									<TD><xsl:value-of select="GBA_Configuration/Interface/SSP_Timeout" />0 msecs</TD>
								</TR>
							</xsl:when>
              <!-- ccNET Mode -->
              <xsl:when test="GBA_Configuration/Interface/@ID[.='10']">
                <TR>
                  <TD>Timeout Period</TD>
                  <TD>
                    <xsl:value-of select="GBA_Configuration/Interface/SSP_Timeout" />0 msecs
                  </TD>
                </TR>
              </xsl:when>
            </xsl:choose>
					</FONT>
				</TABLE>
				<!-- Next Table Shows the OASG data -->
				<HR />
				<H2> OASG Data </H2>
				<TABLE border="1" width="300">
					<FONT size="2">
						<TR>
							<TD width="65%">String Attempts</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/OASG/String_Attempts" />
							</TD>
						</TR>
						<TR>
							<TD>Lockout Period</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/OASG/Lockout_Period" />
							</TD>
						</TR>
						<TR>
							<TD>Recal'n Period</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/OASG/Recal_Period" />
							</TD>
						</TR>
						<TR>
							<TD>Return Note Before Lockout</TD>
							<TD>
                <xsl:choose>
                  <xsl:when test="GBA_Configuration/OASG/Note_Return[.='True']">BEFORE</xsl:when>
                  <xsl:otherwise >AFTER</xsl:otherwise>
                </xsl:choose>
							</TD>
						</TR>
						<TR>
							<TD>Note Detection Limit</TD>
							<TD>
								<xsl:value-of select="GBA_Configuration/OASG/Note_Detect" />
							</TD>
						</TR>
						<TR>
							<TD>String Detect Sensitivity</TD>
							<TD>
								<xsl:choose>
									<xsl:when test="GBA_Configuration/OASG/Sensitivity[.='13']">Low</xsl:when>
									<xsl:when test="GBA_Configuration/OASG/Sensitivity[.='10']">Standard</xsl:when>
									<xsl:when test="GBA_Configuration/OASG/Sensitivity[.='6']">High</xsl:when>
									<xsl:when test="GBA_Configuration/OASG/Sensitivity[.='254']">Disabled</xsl:when>
                  <xsl:otherwise>
                    <xsl:value-of select="GBA_Configuration/OASG/Sensitivity" />
                  </xsl:otherwise>
								</xsl:choose>
							</TD>
							<!-- <TD><xsl:value-of select="GBA_Configuration/OASG/Sensitivity" /></TD> -->
						</TR>
            <xsl:if test="GBA_Configuration/Model[.='GBA HR1']">
              <TR>
                <TD>Foreign Body Check</TD>
                <TD>
                  <xsl:choose>
                    <xsl:when test="GBA_Configuration/OASG/Foreign_Body[.='True']">ON</xsl:when>
                    <xsl:otherwise >OFF</xsl:otherwise>
                  </xsl:choose>
                </TD>
              </TR>
              <TR>
                <TD>OASG Note Shuffle</TD>
                <TD>
                  <xsl:choose>
                    <xsl:when test="GBA_Configuration/OASG/Note_Shuffle[.='0']">OFF</xsl:when>
                    <xsl:when test="GBA_Configuration/OASG/Note_Shuffle[.>'0']">ON</xsl:when>
                    <xsl:otherwise>NOT SET</xsl:otherwise>
                  </xsl:choose>
                </TD>
              </TR>
            </xsl:if>
					</FONT>
				</TABLE>
				<!-- Next Table Shows the General Settings data -->
				<HR />
				<H2> Other Settings </H2>
				<TABLE border="1" width="400">
					<FONT size="2">
						<TR>
							<TD width="65%">Use Low Power Mode</TD>
							<TD>
                <xsl:choose>
                  <xsl:when test="GBA_Configuration/Low_Power[.='True']">ON</xsl:when>
                  <xsl:otherwise >OFF</xsl:otherwise>
                </xsl:choose>
							</TD>
						</TR>
						<TR>
							<TD>Use Magnetic Head</TD>
							<TD>
                <xsl:choose>
                  <xsl:when test="GBA_Configuration/Use_Mag_Head[.='True']">ON</xsl:when>
                  <xsl:otherwise >OFF</xsl:otherwise>
                </xsl:choose>
							</TD>
						</TR>
						<TR>
							<TD>Check for 2 Notes Returning</TD>
							<TD>
                <xsl:choose>
                  <xsl:when test="GBA_Configuration/Two_Note_Return[.='True']">ON</xsl:when>
                  <xsl:otherwise >OFF</xsl:otherwise>
                </xsl:choose>
							</TD>
						</TR>
						<TR>
							<TD>Time Delay before Note Jam Alarm</TD>
							<TD><xsl:value-of select="GBA_Configuration/Note_Jam_Delay" /> msec</TD>
						</TR>
					</FONT>
				</TABLE>
        <!-- Next Table Shows ST1/ST2 specific Settings data -->
        <xsl:if test="GBA_Configuration/Model[.!='GBA HR1']">
          <HR />
          <H2> ST1+/ST1C/ST2 Specific Settings </H2>
          <TABLE border="1" width="450">
			<FONT size="2">
              <TR>
                <TD>Ignore MASG Status</TD>
                <TD>
                  <xsl:choose>
                    <xsl:when test="GBA_Configuration/Ignore_MASG[.='True']">ON</xsl:when>
                    <xsl:otherwise >OFF</xsl:otherwise>
                  </xsl:choose>
                </TD>
              </TR>
              <!-- Rear Exit Sensor Option applies to ST2 only -->
              <xsl:if test="GBA_Configuration/Model[.='GBA_ST2']">
                <TR>
                  <TD>Autoset 2 Note Return Test if Note on Rear Sensor</TD>
                  <TD>
                    <xsl:choose>
                      <xsl:when test="GBA_Configuration/Note_Exit[.='True']">ON</xsl:when>
                      <xsl:otherwise >OFF</xsl:otherwise>
                    </xsl:choose>
                  </TD>
                </TR>              
              </xsl:if>
              <TR>
                <TD>Note Thickness Test Limit</TD>
                <TD>
                  <xsl:value-of select="GBA_Configuration/Note_Thick" />
                </TD>
              </TR>
              <TR>
                <TD>Note Return Test Limit</TD>
                <TD>
                  <xsl:value-of select="GBA_Configuration/Rtrn_Thick" />
                </TD>
              </TR>
              <TR>
                <TD>Enable Bar Code Read</TD>
                <TD>
                  <xsl:choose>
                    <xsl:when test="GBA_Configuration/Enable_BarCode[.='True']">ON</xsl:when>
                    <xsl:otherwise >OFF</xsl:otherwise>
                  </xsl:choose>
                </TD>
              </TR>
              <TR>
                <TD>Bar Code Type</TD>
                <TD>
                  <xsl:choose>
                    <xsl:when test="GBA_Configuration/BarCode_Type[.='0']">None</xsl:when>
                    <xsl:when test="GBA_Configuration/BarCode_Type[.='1']">2 of 5 Interleaved</xsl:when>
                    <xsl:otherwise >Unknown Code</xsl:otherwise>
                  </xsl:choose>
                </TD>
              </TR>
              <TR>
                <TD>Enable Push Button</TD>
                <TD>
                  <xsl:choose>
                    <xsl:when test="GBA_Configuration/Enable_Button[.='True']">ON</xsl:when>
                    <xsl:otherwise >OFF</xsl:otherwise>
                  </xsl:choose>
                </TD>
              </TR>
              <xsl:if test="GBA_Configuration/Enable_Button[.='False']">
                <TR>
                  <TD>Enable Manual Calibration</TD>
                  <TD>
                    <xsl:choose>
                      <xsl:when test="GBA_Configuration/Enable_Man_Cal[.='True']">ON</xsl:when>
                      <xsl:otherwise >OFF</xsl:otherwise>
                    </xsl:choose>
                  </TD>
                </TR>
              </xsl:if>
              <TR>
                <TD>Enable USB Download</TD>
                <TD>
                  <xsl:choose>
                    <xsl:when test="GBA_Configuration/USB_Enable[.='True']">ON</xsl:when>
                    <xsl:otherwise >OFF</xsl:otherwise>
                  </xsl:choose>
                </TD>
              </TR>
              <TR>
                <TD>Note found in ST1 at Power Up</TD>
                <TD>
                  <xsl:choose>
                    <xsl:when test="GBA_Configuration/DumpAtPwrUp[.='True']">STACK IT</xsl:when>
                    <xsl:otherwise >RETURN IT</xsl:otherwise>
                  </xsl:choose>
                </TD>
              </TR>
              <!-- Next section Shows ST2 & ST1C FNG Settings -->
              <xsl:if test="GBA_Configuration/Model[.='GBA_ST2'] or GBA_Configuration/Model[.='GBA_ST1C']">
                <TR>
                  <TD>Flashing Note Guide - Fault</TD>
                  <TD>
                    <xsl:value-of select="GBA_Configuration/FNG_Patterns/FNG_Fault" />
                  </TD>
                </TR>
                <TR>
                  <TD>Flashing Note Guide - Disabled</TD>
                  <TD>
                    <xsl:value-of select="GBA_Configuration/FNG_Patterns/FNG_Disable" />
                  </TD>
                </TR>
                <TR>
                  <TD>Flashing Note Guide - Idle</TD>
                  <TD>
                    <xsl:value-of select="GBA_Configuration/FNG_Patterns/FNG_Idle" />
                  </TD>
                </TR>
                <TR>
                  <TD>Flashing Note Guide - Busy</TD>
                  <TD>
                    <xsl:value-of select="GBA_Configuration/FNG_Patterns/FNG_Busy" />
                  </TD>
                </TR>
              </xsl:if>
            </FONT>
          </TABLE>
        </xsl:if>
 
        <!-- Next Table Shows ST1C DIP Switch Settings data -->
        <xsl:if test="GBA_Configuration/Model[.='GBA_ST1C']">
          <HR />
          <H2> ST1C DIP Switch Settings </H2>
          <TABLE border="1" width="450">
			<FONT size="2">
				<!-- Now fill in function details for each switch present -->
				<xsl:for-each select="GBA_Configuration/DIP_Switch">
					<TR>
					  <TD>
						Switch <xsl:value-of select="@ID" />
					  </TD>
					  <TD>
						<xsl:value-of select="DIP_Descrptn" />
					  </TD>
					</TR>
				</xsl:for-each>
            </FONT>
          </TABLE>
        </xsl:if>
 			  
		<!-- Next Table Shows ST1C String Deterrence Settings -->
        <xsl:if test="GBA_Configuration/String_Deterrence[.!='']">
          <HR />
          <H3> ST1C String Deterrence Settings </H3>
          <TABLE border="1" width="450">
            <FONT size="2">
              <TR>
                <TD>Minimum Delay Before Stacking (s)</TD>
                <TD>
                  <xsl:value-of select="GBA_Configuration/String_Deterrence/MinStackDelay" />
                </TD>
              </TR>
              <TR>
                <TD>Maximum Delay Before Stacking (s)</TD>
                <TD>
                  <xsl:value-of select="GBA_Configuration/String_Deterrence/MaxStackDelay" />
                </TD>
              </TR>
              <TR>
                <TD>Minimum Delay Before Sending Credit (s)</TD>
                <TD>
                  <xsl:value-of select="GBA_Configuration/String_Deterrence/MinCreditDelay" />
                </TD>
              </TR>
              <TR>
                <TD>Maximum Delay Before Sending Credit (s)</TD>
                <TD>
                  <xsl:value-of select="GBA_Configuration/String_Deterrence/MaxCreditDelay" />
                </TD>
              </TR>
              <TR>
                <TD>Lockup after Pullback Detected (mins)</TD>
                <TD>
                  <xsl:value-of select="GBA_Configuration/String_Deterrence/Pullback_Lockout" />
                </TD>
              </TR>
              <TR>
                <TD>Double Punch At Random</TD>
                <TD>
                  <xsl:value-of select="GBA_Configuration/String_Deterrence/Random_Punch" />
                </TD>
              </TR>
            </FONT>
          </TABLE>
        </xsl:if>
      </BODY>
		</HTML>
	</xsl:template>
</xsl:stylesheet>
