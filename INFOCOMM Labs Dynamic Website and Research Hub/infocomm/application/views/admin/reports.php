<?php
//gets the comment reports
$this->db->select('*');
$this->db->from('reportedcomments');
$this->db->join('project_posts_comments', 'project_posts_comments.commentID = reportedcomments.commentID');
$this->db->order_by('RID', 'ASC');
$query = $this->db->get();
$commentReportList = $query->result();

//gets the user reports
$this->db->select('*');
$this->db->from('reportedusers');
$this->db->join('users', 'users.userID = reportedusers.userID');
$this->db->order_by('RID', 'ASC');
$query = $this->db->get();
$userReportList = $query->result();
?> 
 <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Manage Reports
      </h1>
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="row">
        <div class="col-xs-12">
          <div class="box">
            <!-- /.box-header -->
            <div class="box-body"><div class="table table-responsive">
            	<ul class="nav nav-tabs">
				  <li class="active"><a data-toggle="tab" href="#comment">Comment Reports</a></li>
				  <li><a data-toggle="tab" href="#user">User Reports</a></li>
				</ul>
				
				<div class="tab-content">
				  <div id="comment" class="tab-pane fade in active">
				  	<br />
				    <table id="example1" class="table table-bordered table-striped">
	              	<input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />
	                <thead>
		                <tr>
		                  <th>#</th>
		                  <th>Comment</th>
		                  <th>Reason Reported</th>
		                  <th>Manage</th>
		                </tr>
	                </thead>
	                <tbody>
<?php 
$count = 0;
foreach($commentReportList as $cReport)
{
	$count++;
	//prints the row
	echo '
		<tr>
			  <td>'.$count.'</td>
	          <td>'.$cReport->description.'</td>
	          <td>'.$cReport->reason.'</td>
	          <td><button class="btn btn-sm btn-warning" data-type="comment" data-rid="'.$cReport->RID.'" data-cid="'.$cReport->commentID.'" id="btnReportModal" />Manage</button></td>
        </tr>
	';	
}

?>
                	</tbody>
	                <tfoot>
		                <tr>
		                  <th>#</th>
		                  <th>Comment</th>
		                  <th>Reason Reported</th>
		                  <th>Manage</th>
		                </tr>
	                </tfoot>
	              </table>
				    
				    
				    
				  </div>
				  <div id="user" class="tab-pane fade">
				    				  	<br />
				    <table id="example2" class="table table-bordered table-striped">
	              	<input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />
	                <thead>
		                <tr>
		                  <th>#</th>
		                  <th>User</th>
		                  <th>Reason Reported</th>
		                  <th>Manage</th>
		                </tr>
	                </thead>
	                <tbody>
<?php 
$count = 0;
foreach($userReportList as $uReport)
{
	$count++;
	//prints the row
	echo '
		<tr>
			  <td>'.$count.'</td>
	          <td>'.$uReport->fname.' '.$uReport->lname.'</td>
	          <td>'.$uReport->reason.'</td>
	          <td><button class="btn btn-sm btn-warning" data-type="user" data-rid="'.$uReport->RID.'" data-cid="'.$uReport->userID.'" id="btnReportModal" />Manage</button></td>
        </tr>
	';	
}

?>
                	</tbody>
	                <tfoot>
		                <tr>
		                  <th>#</th>
		                  <th>User</th>
		                  <th>Reason Reported</th>
		                  <th>Manage</th>
		                </tr>
	                </tfoot>
	              </table>
				    
				    
				    
				  </div>
				</div>
            </div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->
  </div>
  <!-- /.content-wrapper -->
  
<!-- report-modal -->
<div class="example-modal" >
	<div class="modal" id="modalReport">
	  <div class="modal-dialog">
	    <div class="modal-content">
	      <div class="modal-header">
	        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
	          <span aria-hidden="true">&times;</span></button>
	        <h4 class="modal-title">Manage Report</h4>
	      </div>
	      <div class="modal-body">
	      	<h5>Accepting the report will delete it from the database.</h5> 
	      	<h5>Rejecting the report will delete the report and have no affect on the comment/user.</h5>
	      	<h5 style="color:red">This action cannot be undone.</h5>
	      </div>
	      <form enctype="multipart/form-data">
	      <input type="hidden" name="rID" id="rID" />
	      <input type="hidden" name="cID" id="cID" />
	      <input type="hidden" name="type" id="type" />
	      <div class="modal-footer">
	      	<div class="row center-block">
			    <div class="col-xs-4"><button type="submit" id="btnReject" class="btn btn-danger center-block">Reject</button></div>
			    <div class="col-xs-4"><button type="button" class="btn btn-default center-block" data-dismiss="modal">Close</button></div>
			    <div class="col-xs-4"><button type="submit" id="btnAccept" class="btn btn-success center-block">Accept</button></div>
			</div>
	      </div>
	      </form>
	    </div>
	    <!-- /.modal-content -->
	  </div>
	  <!-- /.modal-dialog -->
	</div>
	<!-- /.modal -->
</div>
<!-- /.report-modal -->


<!-- ./wrapper -->

<!-- jQuery 2.2.3 -->
<script src="<?php echo base_url(); ?>plugins/jQuery/jquery-2.2.3.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="<?php echo base_url(); ?>bootstrap/js/bootstrap.min.js"></script>
<!-- DataTables -->
<script src="<?php echo base_url(); ?>plugins/datatables/jquery.dataTables.min.js"></script>
<script src="<?php echo base_url(); ?>plugins/datatables/dataTables.bootstrap.min.js"></script>
<!-- SlimScroll -->
<script src="<?php echo base_url(); ?>plugins/slimScroll/jquery.slimscroll.min.js"></script>
<!-- FastClick -->
<script src="<?php echo base_url(); ?>plugins/fastclick/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="<?php echo base_url(); ?>dist/js/app.min.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="<?php echo base_url(); ?>dist/js/demo.js"></script>
<!-- page script -->
<script>
  $(function () {
    $("#example1").DataTable();
    $("#example2").DataTable();
  });
</script>
<script>
$(document).ready(function() {
	//Approval Modal function
	$(document).on('click', "#btnReportModal",function() {
		
		//gets the userID
		var commentID = $(this).data("cid");
		var reportID = $(this).data("rid");
		var type = $(this).data("type");

		//passes the value to the modal
		$("#type").val(type);
		$("#rID").val(reportID);
		$("#cID").val(commentID);
		
		//shows the modal
		$('#modalReport').modal('show');
	});
	
	//Reject function called from Approval Modal
	$(document).on('click', "#btnReject",function(e) {
		e.preventDefault();
		
		var type = $("#type").val();
		var rID = $("#rID").val();
		
		//confirms
		var c = confirm('Are you sure you want to reject this report and let the comment/user be?');
		
		if (c)
		{
			//posts to the controller
			$.post("reports/reject",{rID:rID, type:type}, function(result, status){
		        if (status)
		        {
		        	alert("Report Deleted!");
		        	window.location = $("#baseURL").val() + "admin/reports";
		        }
		        else
		        {
		        	alert("Error!");
		        }
		    });
		}
	});
	
	//Accepting function called from Approval Modal
	$(document).on('click', "#btnAccept",function(e) {
		e.preventDefault();
		
		var type = $("#type").val();
		var cID = $("#cID").val();
		
		//confirms
		var c = confirm('Are you sure you want to accept this report and delete the comment/user?');
		
		if (c)
		{
			//posts to the controller					
			$.post("reports/accept",{cID:cID, type:type}, function(result, status){
		        if (status)
		        {
		        	alert("Comment/User Deleted!");
		        	window.location = $("#baseURL").val() + "admin/reports";
		        }
		        else
		        {
		        	alert("Error!");
		        }
		    });
		}
	});
	
});
</script>