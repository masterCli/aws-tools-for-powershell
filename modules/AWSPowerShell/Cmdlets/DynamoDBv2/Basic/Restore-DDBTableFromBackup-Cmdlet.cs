/*******************************************************************************
 *  Copyright 2012-2019 Amazon.com, Inc. or its affiliates. All Rights Reserved.
 *  Licensed under the Apache License, Version 2.0 (the "License"). You may not use
 *  this file except in compliance with the License. A copy of the License is located at
 *
 *  http://aws.amazon.com/apache2.0
 *
 *  or in the "license" file accompanying this file.
 *  This file is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR
 *  CONDITIONS OF ANY KIND, either express or implied. See the License for the
 *  specific language governing permissions and limitations under the License.
 * *****************************************************************************
 *
 *  AWS Tools for Windows (TM) PowerShell (TM)
 *
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Management.Automation;
using System.Text;
using Amazon.PowerShell.Common;
using Amazon.Runtime;
using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace Amazon.PowerShell.Cmdlets.DDB
{
    /// <summary>
    /// Creates a new table from an existing backup. Any number of users can execute up to
    /// 4 concurrent restores (any type of restore) in a given account. 
    /// 
    ///  
    /// <para>
    /// You can call <code>RestoreTableFromBackup</code> at a maximum rate of 10 times per
    /// second.
    /// </para><para>
    /// You must manually set up the following on the restored table:
    /// </para><ul><li><para>
    /// Auto scaling policies
    /// </para></li><li><para>
    /// IAM policies
    /// </para></li><li><para>
    /// Amazon CloudWatch metrics and alarms
    /// </para></li><li><para>
    /// Tags
    /// </para></li><li><para>
    /// Stream settings
    /// </para></li><li><para>
    /// Time to Live (TTL) settings
    /// </para></li></ul>
    /// </summary>
    [Cmdlet("Restore", "DDBTableFromBackup", SupportsShouldProcess = true, ConfirmImpact = ConfirmImpact.Medium)]
    [OutputType("Amazon.DynamoDBv2.Model.TableDescription")]
    [AWSCmdlet("Calls the Amazon DynamoDB RestoreTableFromBackup API operation.", Operation = new[] {"RestoreTableFromBackup"}, SelectReturnType = typeof(Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse))]
    [AWSCmdletOutput("Amazon.DynamoDBv2.Model.TableDescription or Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse",
        "This cmdlet returns an Amazon.DynamoDBv2.Model.TableDescription object.",
        "The service call response (type Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse) can also be referenced from properties attached to the cmdlet entry in the $AWSHistory stack."
    )]
    public partial class RestoreDDBTableFromBackupCmdlet : AmazonDynamoDBClientCmdlet, IExecutor
    {
        
        #region Parameter BackupArn
        /// <summary>
        /// <para>
        /// <para>The Amazon Resource Name (ARN) associated with the backup.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        #else
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String BackupArn { get; set; }
        #endregion
        
        #region Parameter TargetTableName
        /// <summary>
        /// <para>
        /// <para>The name of the new table to which the backup must be restored.</para>
        /// </para>
        /// </summary>
        #if !MODULAR
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true)]
        #else
        [System.Management.Automation.Parameter(Position = 0, ValueFromPipelineByPropertyName = true, ValueFromPipeline = true, Mandatory = true)]
        [System.Management.Automation.AllowEmptyString]
        [System.Management.Automation.AllowNull]
        #endif
        [Amazon.PowerShell.Common.AWSRequiredParameter]
        public System.String TargetTableName { get; set; }
        #endregion
        
        #region Parameter Select
        /// <summary>
        /// Use the -Select parameter to control the cmdlet output. The default value is 'TableDescription'.
        /// Specifying -Select '*' will result in the cmdlet returning the whole service response (Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse).
        /// Specifying the name of a property of type Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse will result in that property being returned.
        /// Specifying -Select '^ParameterName' will result in the cmdlet returning the selected cmdlet parameter value.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public string Select { get; set; } = "TableDescription";
        #endregion
        
        #region Parameter PassThru
        /// <summary>
        /// Changes the cmdlet behavior to return the value passed to the TargetTableName parameter.
        /// The -PassThru parameter is deprecated, use -Select '^TargetTableName' instead. This parameter will be removed in a future version.
        /// </summary>
        [System.Obsolete("The -PassThru parameter is deprecated, use -Select '^TargetTableName' instead. This parameter will be removed in a future version.")]
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter PassThru { get; set; }
        #endregion
        
        #region Parameter Force
        /// <summary>
        /// This parameter overrides confirmation prompts to force 
        /// the cmdlet to continue its operation. This parameter should always
        /// be used with caution.
        /// </summary>
        [System.Management.Automation.Parameter(ValueFromPipelineByPropertyName = true)]
        public SwitchParameter Force { get; set; }
        #endregion
        
        protected override void ProcessRecord()
        {
            base.ProcessRecord();
            
            var resourceIdentifiersText = FormatParameterValuesForConfirmationMsg(nameof(this.TargetTableName), MyInvocation.BoundParameters);
            if (!ConfirmShouldProceed(this.Force.IsPresent, resourceIdentifiersText, "Restore-DDBTableFromBackup (RestoreTableFromBackup)"))
            {
                return;
            }
            
            var context = new CmdletContext();
            
            // allow for manipulation of parameters prior to loading into context
            PreExecutionContextLoad(context);
            
            #pragma warning disable CS0618, CS0612 //A class member was marked with the Obsolete attribute
            if (ParameterWasBound(nameof(this.Select)))
            {
                context.Select = CreateSelectDelegate<Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse, RestoreDDBTableFromBackupCmdlet>(Select) ??
                    throw new System.ArgumentException("Invalid value for -Select parameter.", nameof(this.Select));
                if (this.PassThru.IsPresent)
                {
                    throw new System.ArgumentException("-PassThru cannot be used when -Select is specified.", nameof(this.Select));
                }
            }
            else if (this.PassThru.IsPresent)
            {
                context.Select = (response, cmdlet) => this.TargetTableName;
            }
            #pragma warning restore CS0618, CS0612 //A class member was marked with the Obsolete attribute
            context.BackupArn = this.BackupArn;
            #if MODULAR
            if (this.BackupArn == null && ParameterWasBound(nameof(this.BackupArn)))
            {
                WriteWarning("You are passing $null as a value for parameter BackupArn which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            context.TargetTableName = this.TargetTableName;
            #if MODULAR
            if (this.TargetTableName == null && ParameterWasBound(nameof(this.TargetTableName)))
            {
                WriteWarning("You are passing $null as a value for parameter TargetTableName which is marked as required. In case you believe this parameter was incorrectly marked as required, report this by opening an issue at https://github.com/aws/aws-tools-for-powershell/issues.");
            }
            #endif
            
            // allow further manipulation of loaded context prior to processing
            PostExecutionContextLoad(context);
            
            var output = Execute(context) as CmdletOutput;
            ProcessOutput(output);
        }
        
        #region IExecutor Members
        
        public object Execute(ExecutorContext context)
        {
            var cmdletContext = context as CmdletContext;
            // create request
            var request = new Amazon.DynamoDBv2.Model.RestoreTableFromBackupRequest();
            
            if (cmdletContext.BackupArn != null)
            {
                request.BackupArn = cmdletContext.BackupArn;
            }
            if (cmdletContext.TargetTableName != null)
            {
                request.TargetTableName = cmdletContext.TargetTableName;
            }
            
            CmdletOutput output;
            
            // issue call
            var client = Client ?? CreateClient(_CurrentCredentials, _RegionEndpoint);
            try
            {
                var response = CallAWSServiceOperation(client, request);
                object pipelineOutput = null;
                pipelineOutput = cmdletContext.Select(response, this);
                output = new CmdletOutput
                {
                    PipelineOutput = pipelineOutput,
                    ServiceResponse = response
                };
            }
            catch (Exception e)
            {
                output = new CmdletOutput { ErrorResponse = e };
            }
            
            return output;
        }
        
        public ExecutorContext CreateContext()
        {
            return new CmdletContext();
        }
        
        #endregion
        
        #region AWS Service Operation Call
        
        private Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse CallAWSServiceOperation(IAmazonDynamoDB client, Amazon.DynamoDBv2.Model.RestoreTableFromBackupRequest request)
        {
            Utils.Common.WriteVerboseEndpointMessage(this, client.Config, "Amazon DynamoDB", "RestoreTableFromBackup");
            try
            {
                #if DESKTOP
                return client.RestoreTableFromBackup(request);
                #elif CORECLR
                return client.RestoreTableFromBackupAsync(request).GetAwaiter().GetResult();
                #else
                        #error "Unknown build edition"
                #endif
            }
            catch (AmazonServiceException exc)
            {
                var webException = exc.InnerException as System.Net.WebException;
                if (webException != null)
                {
                    throw new Exception(Utils.Common.FormatNameResolutionFailureMessage(client.Config, webException.Message), webException);
                }
                throw;
            }
        }
        
        #endregion
        
        internal partial class CmdletContext : ExecutorContext
        {
            public System.String BackupArn { get; set; }
            public System.String TargetTableName { get; set; }
            public System.Func<Amazon.DynamoDBv2.Model.RestoreTableFromBackupResponse, RestoreDDBTableFromBackupCmdlet, object> Select { get; set; } =
                (response, cmdlet) => response.TableDescription;
        }
        
    }
}