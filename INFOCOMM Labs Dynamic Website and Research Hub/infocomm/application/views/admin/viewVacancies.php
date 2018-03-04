<?php
$query = $this->db->get("vacancies");
$output = $query->result();
?> 

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        View Vacancies
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
	                  <th>Category</th>
	                  <th>Title</th>
	                  <th>Description</th>
	                  <th>Deadline</th>
	                  <th>Date Posted</th>
	                  <th>Login Required</th>
	                  <th>Fill</th>
	                  <th>Edit</th>
	                  <th>Delete</th>
	                </tr>
                </thead>
                <tbody>
                	
<?php

foreach($output as $o)
{
	//Checks if it is filled
	if($o->isFilled == 'No')
	{
		$isFilled = '<td><button class="btn btn-sm btn-primary" data-id="'.$o->vID.'" id="btnVacancyFill"/>fill</button></td>';
	}
	else 
	{
		$isFilled = '<td></td>';
	}
	
	//Checks if login is required and displays yes/no
	if ($o->loginRequired == 1)
	{
		$req = 'Yes';
	}
	else
	{
		$req = 'No';
	}
	
	$date=date_create($o->dateCreated);
	$created = date_format($date,"Y-m-d");	
	
	//prints the row
	echo '
		<tr>
	          <td>'.$o->vCat.'</td>
	          <td>'.$o->title.'</td>
	          <td>'.$o->description.'</td>
	          <td>'.$o->deadline.'</td>
	          <td>'.$created.'</td>
	          <td>'.$req.'</td>
	          '.$isFilled.'
	          <td><button class="btn btn-sm btn-warning" data-id="'.$o->vID.'" data-title="'.$o->title.'"  data-desc="'.htmlentities($o->description).'" data-deadline="'.$o->deadline.'" id="btnEditVacancy" />edit</button></td>
	          <td><button class="btn btn-sm btn-danger" data-id2="'.$o->vID.'" id="btnVacancy"/>delete</button></td>
        </tr>
	';	
}

?>	                
                </tbody>
                <tfoot>
	                <tr>
	                  <th>Category</th>
	                  <th>Title</th>
	                  <th>Description</th>
	                  <th>Deadline</th>
	                  <th>Date Posted</th>
	                  <th>Login Required</th>
	                  <th>Fill</th>
	                  <th>Edit</th>
	                  <th>Delete</th>
	                </tr>
                </tfoot>
              </table>
            </div>
            <!-- /.box-body -->
          </div></div>
          <!-- /.box -->
        </div>
        <!-- /.col -->
      </div>
      <!-- /.row -->
    </section>
    <!-- Content Header (Page header) -->    
  </div>
  <!-- /.content-wrapper -->
 
 
<!-- edit-vacancy-modal -->
<div class="example-modal" >
	<div class="modal" id="modalEditVacancy">
	  <div class="modal-dialog">
	    <div class="modal-content">
	      <div class="modal-header">
	        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
	          <span aria-hidden="true">&times;</span></button>
	        <h4 class="modal-title">Edit Vacancy</h4>
	      </div>
	      <div class="modal-body">
	      	<div class="row">
	      		<div class="col-xs-12">
			      	
			      	<div class="form-group">
	                  <input type="text" class="form-control" id="titleModal" placeholder="Title">
	                </div>
	                
	                <div class="form-group">
		                <div class="input-group date">
		                  <div class="input-group-addon">
		                    <i class="fa fa-calendar"></i>
		                  </div>
		                  <input type="text" class="form-control pull-right" id="datepicker" placeholder="Deadline">
		                </div>
		            </div>
		            
	              	<div class="form-group">
	                  <textarea class="form-control" rows="3" id="descriptionModal" placeholder="Description"></textarea>
	                </div>
	      		</div>
	      	</div>
	      </div>
	      <input type="hidden" id="vIDModal" />
	      <div class="modal-footer">
	        <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
	        <button type="button" id="btnEditVacancyModal" class="btn btn-success">Save Changes</button>
	      </div>
	    </div>
	    <!-- /.modal-content -->
	  </div>
	  <!-- /.modal-dialog -->
	</div>
	<!-- /.modal -->
</div>
<!-- /.edit-vacancy-modal -->
  
<!-- includes footer -->

<!-- ./wrapper -->

<!-- jQuery 2.2.3 -->
<script src="<?php echo base_url(); ?>plugins/jQuery/jquery-2.2.3.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="<?php echo base_url(); ?>bootstrap/js/bootstrap.min.js"></script>
<!-- DataTables -->
<script src="<?php echo base_url(); ?>plugins/datatables/jquery.dataTables.min.js"></script>
<script src="<?php echo base_url(); ?>plugins/datatables/dataTables.bootstrap.min.js"></script>
<!-- bootstrap datepicker -->
<script src="<?php echo base_url(); ?>plugins/datepicker/bootstrap-datepicker.js"></script>
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
  $(function () {
    //Date picker
    $('#datepicker').datepicker({
      autoclose: true
    });
  });
</script>
<script>
	//Delete Vacancy
	$(document).ready(function() {
		$(document).on('click', "#btnVacancy",function() {
			
			var data = $(this).data("id2");
			
			var c = confirm('Are you sure you want to delete this vacancy?');
			
			if (c)
			{
				$.post('viewVacancies/delete',{id:data}, function(result, status){
			        if (status)
			        {
			        	alert("Vacancy Deleted Successfully!");
			        	window.location = $("#baseURL").val() + "admin/viewVacancies";
			        }
			        else
			        {
			        	alert("Error!");
			        }
			    });
			}
		});
	});
	
	//Fill Vacancy
	$(document).ready(function() {
		$(document).on('click', "#btnVacancyFill",function() {
			
			var id = $(this).data("id");
			
			var c = confirm('Are you sure this vacancy is filled?');
			
			if (c)
			{
				$.post('viewVacancies/fill',{id:id}, function(result, status){
			        if (status)
			        {
			        	alert("Vacancy Filled Successfully!");
			        	window.location = $("#baseURL").val() + "admin/viewVacancies";
			        }
			        else
			        {
			        	alert("Error!");
			        }
			    });
			}
		});
	});
	
	//Edit Vacancy Modal
 	$(document).ready(function() {
		$(document).on('click', "#btnEditVacancy",function() {
			
			//gets the data
			var vID = $(this).data("id");
			var description = $(this).data("desc");
			var title = $(this).data("title");
			var deadline = $(this).data("deadline");

			//passes the value to the modal
			$("#vIDModal").val(vID);
			$("#titleModal").val(title);
			$("#descriptionModal").val(description);
			$("#datepicker").val(deadline);
			
			//shows the modal
			$('#modalEditVacancy').modal('show');
		});
	});
	 
	//Edit Vacancy function
	$(document).ready(function() {
		$(document).on('click', "#btnEditVacancyModal",function(e) {
			
			e.preventDefault();
			
			$('#modalEditVacancy').modal('hide');
			
			var id = $('#vIDModal').val();
			var title = $('#titleModal').val();
			var description = $('#descriptionModal').val();
			var deadline = $("#datepicker").val();
			var deadlineDate = $("#datepicker").datepicker("getDate");
			
			var CurrentDate = new Date();
			if ((deadlineDate - CurrentDate) < 0)
			{
				alert("Date cannot be set to before today!");
				$('#modalEditVacancy').modal('show');
			} 
			else
			{		
				var c = confirm('Are you sure you want to save these changes?');
				
				if (c)
				{
					$.post('viewVacancies/edit',{id:id, title:title, description:description, deadline:deadline}, function(result, status){
				        if (status)
				        {
				        	alert("Changes Successful!");
				        	window.location = $("#baseURL").val() + "admin/viewVacancies";
				        }
				        else
				        {
				        	alert("Error!");
				        }
				    });
				}
			}
		});
	});
</script>
