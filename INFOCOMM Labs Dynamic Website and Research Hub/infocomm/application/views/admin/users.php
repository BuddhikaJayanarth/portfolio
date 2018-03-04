<?php
//queries the databse for the users table
$query = $this->db->get("users");
$output = $query->result();
?> 
 <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Users
      </h1>
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="row">
        <div class="col-xs-12">
          <div class="box">
            <!-- /.box-header -->
            
            <div class="box-body"><div class="table table-responsive">
              <table id="example1" class="table table-bordered table-striped">
              	<input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />
                <thead>
                <tr>
               	  <th>ID</th>
                  <th>Name</th>
                  <th>DOB</th>
                  <th>Email</th>
                  <th>Phone</th>
                  <th>City</th>
                  <th>Country</th>
                  <th>Type</th>
                  <th>Access</th>
                  <th>Status</th>
                  <th>Delete</th>
                  <th>Edit Access</th>
                </tr>
                </thead>
                <tbody>
                	
<?php
//runs through all the results from the query and gets the information from them
foreach($output as $o)
{
	//creates date to display
	$date = date_create($o->dob);
	$dobDisplay = date_format($date, 'd/m/Y');
	
	//Gets the type and makes sure the edit access only shows us if the user is infocomm since the general users are only level 4
	$type = $o->userType;
	if ($type == 'I')
	{
		$type = 'Infocomm';
		$editA = '<td><button class="btn btn-sm btn-warning" data-id1="'.$o->userID.'" data-id2="'.$o->accessLevel.'" id="btnEditAccess" />edit access</button></td>';
	}
	else if ($type == 'G')
	{
		$type = 'General';
		$editA = '<td></td>';
	}
	
	//Sets the appropriate label for the status of the user
	$status = $o->status;
	if ($status == 'Approved')
	{
		$status = '<span class="label label-success">Approved</span>';
	}
	else if ($status == 'Pending')
	{
		$status = '<span class="label label-warning">Pending</span>';
	}
	else if ($status == 'Activated')
	{
		$status = '<span class="label label-primary">Activated</span>';
	}
	else if ($status == 'Deactivated')
	{
		$status = '<span class="label bg-gray" style="color:#FFF">Deactivated</span>';
	}
	else if ($status == 'Suspended')
	{
		$status = '<span class="label label-info">Suspended</span>';
	}
	
	//prints the row
	echo '
		<tr>
				  <td>'.$o->userID.'</td> <input type="hidden" value="'.$o->userID.'" name="id" />
                  <td>'.$o->fname.' '.$o->lname.'</td>
                  <td>'.$dobDisplay.'</td>
                  <td>'.$o->email.'</td>
                  <td>'.$o->phone.'</td>
                  <td>'.$o->city.'</td>
                  <td>'.$o->country.'</td>
                  <td>'.$type.'</td>
                  <td>'.$o->accessLevel.'</td>
                  <td>'.$status.'</td>
                  <td><button class="btn btn-sm btn-danger" data-id1="'.$o->userID.'" id="btnDeleteUser" />delete</button></td>
                  '.$editA.'
        
        </tr>
	';	
}
?>
                
               </tbody>
                <tfoot>
                <tr>
                  <th>ID</th>
                  <th>Name</th>
                  <th>DOB</th>
                  <th>Email</th>
                  <th>Phone</th>
                  <th>City</th>
                  <th>Country</th>
                  <th>Type</th>
                  <th>Access</th>
                  <th>Status</th>
                  <th>Delete</th>
                  <th>Edit Access</th>
                </tr>
                </tfoot>
              </table></div>
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
  
<!-- edit-access-modal -->
<div class="example-modal" >
	<div class="modal" id="modalEditAccess">
	  <div class="modal-dialog">
	    <div class="modal-content">
	      <div class="modal-header">
	        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
	          <span aria-hidden="true">&times;</span></button>
	        <h4 class="modal-title">Edit Access</h4>
	      </div>
	      <div class="modal-body">
	      	<div class="row">
	      		<div class="col-xs-6">
			      	<p>Select New Access Level: </p>
			        <select id="currentAccess">
			        	<option>1</option>
			        	<option>2</option>
			        	<option>3</option>
			        </select>
	      		</div>
	      		<div class="col-xs-6">
			      	<p>Access Level Key: </p>
			        <p>1 - Super Admin Full Privileges</p>
			        <p>2 - Accept Users / Add &amp; Manage Projects</p>
			        <p>3 - Infocomm User</p>
			        <p>4 - General User</p>
	      		</div>
	      	</div>
	      </div>
	      <input type="hidden" id="userIDAccessModal" />
	      <div class="modal-footer">
	        <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
	        <button type="button" id="btnChangeAccessLevel" class="btn btn-success">Change Access Level</button>
	      </div>
	    </div>
	    <!-- /.modal-content -->
	  </div>
	  <!-- /.modal-dialog -->
	</div>
	<!-- /.modal -->
</div>
<!-- /.edit-access-modal -->

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
  });
</script>
<script>
//Delete User function
$(document).ready(function() {
	
	$(document).on('click', "#btnDeleteUser",function() {
		
		//gets the id
		var data = $(this).data("id1");
		
		//prompts for confirmation
		var c = confirm('Are you sure you want to delete this user?');
		
		if (c)
		{
			//posts to the controller
			$.post('users/delete',{id:data}, function(result, status){
		        if (status)
		        {
		        	alert("User Deleted Successfully!");
		        	window.location = $("#baseURL").val() + "admin/users";
		        }
		        else
		        {
		        	alert("Error!");
		        }
		    });
		}
	});
	
	//Edit access modal function
	$(document).on('click', "#btnEditAccess",function() {
		
		//gets the userID and the access level from the data-id
		var id = $(this).data("id1");
		var access = $(this).data("id2");

		//passes the value to the modal
		$("#currentAccess").val(access);
		$("#userIDAccessModal").val(id);
		
		//shows the modal
		$('#modalEditAccess').modal('show');
	});
	
	//Edit Access function
	$(document).on('click', "#btnChangeAccessLevel",function() {
		
		//gets the new access and the userID
		var id = $('#userIDAccessModal').val();
		var access = $('#currentAccess :selected').val();
		
		//confirms				
		var c = confirm('Are you sure you want to change access for this user?');
		
		if (c)
		{
			//posts to the controller
			$.post('users/editAccess',{uid:id, accessL:access}, function(result, status){
		        if (status)
		        {
		        	alert("User Access Level Change Successfully!");
		        	window.location = $("#baseURL").val() + "admin/users";
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