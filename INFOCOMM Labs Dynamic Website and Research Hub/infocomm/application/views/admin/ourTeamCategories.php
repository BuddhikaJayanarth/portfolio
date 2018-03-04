<?php
//retrieves all employee positions in Infocomm from the database
$query = $this->db->get("positions");
$output = $query->result();

?> 

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Team Categories
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
	                  <th>Designation/Postion</th>
	                  <th>Priority</th>
                      <th>Edit Priority</th>
                      <th>Delete Position</th>
	                </tr>
                </thead>
                <tbody>
<?php
//populates table with every row form table
foreach($output as $o)
{
		
	echo '
				<tr>
					<td>'.$o->designation.'</td>
					<td>'.$o->shownInOurteam.'</td>
					<td><button class="btn btn-sm btn-warning" data-designation="'.$o->designation.'" data-priority="'.$o->shownInOurteam.'" id="btnEdit" />Edit Priority</button></td>
					<td><button class="btn btn-sm btn-danger" data-designation="'.$o->designation.'" id="btnDelete"/>delete</button></td>
				</tr>
	';	
         
}
?>
                </tbody>
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
    
<!-- edit-priority-modal -->
<div class="example-modal" >
	<div class="modal" id="modalEdit">
	  <div class="modal-dialog">
	    <div class="modal-content">
	      <div class="modal-header">
	        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
	          <span aria-hidden="true">&times;</span></button>
	        <h4 class="modal-title">Edit Prority</h4>
	      </div>
	      <div class="modal-body">
	      	<div class="row">
	      		<div class="col-xs-12">
			      	
			      	<div class="form-group">
	                  <input type="text" class="form-control" id="priorityModal" placeholder="Priority (1:highest, 2:second highest, 0:no priority, -1:Don't display)" required="required">
	                </div>
	      		</div>
	      	</div>
	      </div>
	      <input type="hidden" id="designationModal" />
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
<!-- /.edit-priority-modal -->
    
    
    <section class="content">
    	
      <div class="row">
        <!-- left column -->
        <div class="col-md-6">
          <!-- general form elements -->
          <div class="box box-success">
          	<div class="box-header with-border">
              <h3 class="box-title">Add Position</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
            <form name="addPos">
              <div class="box-body">
                
                <div class="form-group">
                  <input type="text" class="form-control" id="desig" placeholder="Designation" required="required">
                </div>
                
                <div class="form-group">
                  <input type="text" class="form-control" id="prio" placeholder="Priority (1:highest, 2:second highest, 0:no priority, -1:Don't display)" required="required">
                </div>
                
              <div class="box-footer">
                <button id="btnAddCollab" class="btn btn-success">Add</button>
              </div>
            </form>
          </div>
          <!-- /.box -->
        </div>
        <!--/.col (right) -->
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->
    
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


				/////////////////////////////////////////////////////////////////////
				/**
				*** delete position function
				**/
				/////////////////////////////////////////////////////////////////////

		$(document).on('click', "#btnDelete",function() {
			
			//gets designation from button
			var designation = $(this).data("designation");

			if (confirm('Are you sure you want to delete this position?') == true)
			{
				//posts to delete position from positions table
				$.post('ourTeamCategories/remove',{desig:designation}, function(result, status){
			        if (status)
			        {
			        	alert("Position deleted");
			        	location.reload(true);
			        }
			        else
			        {
			        	alert("Error!");
			        }
			    });			
			
			}
		});
		
				/////////////////////////////////////////////////////////////////////
				/**
				*** edit position in modal function
				**/
				/////////////////////////////////////////////////////////////////////
		$(document).on('click', "#btnEdit",function() {
			
			//gets the data in button and assign to variables
			var designation = $(this).data("designation");
			var priority = $(this).data("priority");
			
			//populates modal with values in variables
			$("#designationModal").val(designation);
			$("#priorityModal").val(priority);
			
			//shows the modal
			$('#modalEdit').modal('show');
		});
		
		//Post to update position table
		$(document).on('click', "#btnEditModal",function() {
			
			$('#modalEdit').modal('hide');
			
			var designation = $('#designationModal').val();
			var priority = $("#priorityModal").val();
			
			if (confirm('Are you sure you want to save these changes?')== true)
			{
				$.post('ourTeamCategories/edit',{designation:designation, priority:priority}, function(result, status){
			        if (status)
			        {
			        	alert("Position updated");
			        	location.reload(true);
			        }
			        else
			        {
			        	alert("Error!");
			        }
			    });
			}
		});
		
				/////////////////////////////////////////////////////////////////////
				/**
				*** Method to add a new position
				**/
				/////////////////////////////////////////////////////////////////////
		$(document).on('click', "#btnAddCollab",function() {
			
			//gets values from form
			var designation = $("#desig").val();
			var priority = $("#prio").val();
			
			//posts to add new position in positions table
			$.post('ourTeamCategories/add',{designation:designation, priority:priority}, function(result, status){
		        if (status)
			        {
			        	alert("Position added");
			        	location.reload(true);
			        }
			        else
			        {
			        	alert("Error!");
			        }
		    });
		});
	});
</script>