<?php
//queries the databse for the collaborators table
$query = $this->db->get("collaborators");
$output = $query->result();
$count = 0;
?> 

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Collaborators
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
                <thead>
	                <tr>
	                  <th>#</th>
	                  <th>Affiliation</th>
	                  <th>Department</th>
	                  <th>Contact Person</th>
	                  <th>Website</th>
	                  <th>Edit</th>
	                  <th>Delete</th>
	                </tr>
                </thead>
                <tbody>
<?php
//runs through all the results from the query and gets the information from them
foreach($output as $o)
{
	//increases the count to print the values
	$count++;
		
	//prints out rows
	echo '
				<tr>
					<td>'.$count.'</td>
					<td>'.$o->affiliation.'</td>
					<td>'.$o->department.'</td>
					<td>'.$o->contactPerson.'</td>
					<td>'.$o->website.'</td>
					<td><button class="btn btn-sm btn-warning" data-contact="'.$o->contactPerson.'" data-id="'.$o->collaboratorID.'" data-website="'.$o->website.'" data-dept="'.$o->department.'"  data-affiliation="'.$o->affiliation.'"  id="btnEdit" />edit</button></td>
					<td><button class="btn btn-sm btn-danger" data-id="'.$o->collaboratorID.'" id="btnDelete"/>delete</button></td>
				</tr>
	';	
         
}
?>
                </tbody>
                <tfoot>
	                <tr>
	                  <tr>
	                  <th>#</th>
	                  <th>Affiliation</th>
	                  <th>Department</th>
	                  <th>Contact Person</th>
	                  <th>Website</th>
	                  <th>Edit</th>
	                  <th>Delete</th>
	                </tr>
                </tfoot>
              </table>
            </div></div>
            <!-- /.box-body -->
          </div>
          <!-- /.box -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->
    
<!-- edit-collaborators-modal -->
<div class="example-modal" >
	<div class="modal" id="modalEdit">
	  <div class="modal-dialog">
	    <div class="modal-content">
	      <div class="modal-header">
	        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
	          <span aria-hidden="true">&times;</span></button>
	        <h4 class="modal-title">Edit Collaborator</h4>
	      </div>
	      <div class="modal-body">
	      	<div class="row">
	      		<div class="col-xs-12">
			      	<input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />
			      	
			      	<div class="form-group">
	                  <input type="text" class="form-control" id="affiliationModal" placeholder="Affiliation" disabled="disabled">
	                </div>
	                
	                <div class="form-group">
	                  <input type="text" class="form-control" id="departmentModal" placeholder="Department" disabled="disabled">
	                </div>
	                
	                <div class="form-group">
	                  <input type="text" class="form-control" id="contactPersonModal" placeholder="Contact Person">
	                </div>
	                
	                <div class="form-group">
	                  <input type="text" class="form-control" id="websiteModal" placeholder="Website">
	                </div>
	      		</div>
	      	</div>
	      </div>
	      <input type="hidden" id="cIDModal" />
	      <div class="modal-footer">
	        <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
	        <button type="button" id="btnEditModal" class="btn btn-success">Save Changes</button>
	      </div>
	    </div>
	    <!-- /.modal-content -->
	  </div>
	  <!-- /.modal-dialog -->
	</div>
	<!-- /.modal -->
</div>
<!-- /.edit-collaborators-modal -->
        
  </div>
  <!-- /.content-wrapper -->
  
  
  

    <!-- Add the sidebar's background. This div must be placed
       immediately after the control sidebar -->
  <div class="control-sidebar-bg"></div>
</div>
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
    $('#example2').DataTable({
      "paging": true,
      "lengthChange": false,
      "searching": false,
      "ordering": true,
      "info": true,
      "autoWidth": false
    });
  });
</script>
<script>
	$(document).ready(function() {
		//Delete Function
		$(document).on('click', "#btnDelete",function() {
			
			//gets the id of the collaborator to be deleted
			var id = $(this).data("id");
			
			var c = confirm('Are you sure you want to delete this collaborator?');
			
			if (c)
			{
				//posts the value to be deleted to the controller
				$.post('collaborators/delete',{id:id}, function(result, status){
			        if (status)
			        {
			        	alert("Collaborator deleted!");
			        	window.location = $("#baseURL").val() + "admin/collaborators";
			        }
			        else
			        {
			        	alert("Error!");
			        }
			    });			
			
			}
		});
		
		//Edit Collaborators button click function
		$(document).on('click', "#btnEdit",function() {
			
			//gets the data
			var cID = $(this).data("id");
			var dept = $(this).data("dept");
			var affiliation = $(this).data("affiliation");
			var contactPerson = $(this).data("contact");
			var website = $(this).data("website");
			
			//passes the value to the modal
			$("#cIDModal").val(cID);
			$("#affiliationModal").val(affiliation);
			$("#departmentModal").val(dept);
			$("#contactPersonModal").val(contactPerson);
			$("#websiteModal").val(website);
			
			//shows the modal
			$('#modalEdit').modal('show');
		});
		
		//Edit Collaborators post data function
		$(document).on('click', "#btnEditModal",function(e) {
			
			e.preventDefault();
			
			$('#modalEdit').modal('hide');
			
			var id = $('#cIDModal').val();
			var contactPerson = $("#contactPersonModal").val();
			var website = $("#websiteModal").val();
						
			var c = confirm('Are you sure you want to save these changes?');
			
			if (c)
			{
				$.post('collaborators/edit',{id:id, contactPerson:contactPerson, website:website}, function(result, status){
			        if (status)
			        {
			        	alert("Changes Successful!");
			        	window.location = $("#baseURL").val() + "admin/collaborators";
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