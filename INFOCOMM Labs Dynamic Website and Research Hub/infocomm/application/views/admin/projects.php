<?php
//retrieves projects from user_projects table in database
$query = $this->db->get("user_projects");
$this->db->select('*');
$this->db->from('user_projects');
$this->db->join('users', 'user_projects.userID = users.userID');
$query = $this->db->get();
$output = $query->result();
?> 

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Projects
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
	                  <th>Project ID</th>
	                  <th>Project Title</th>
	                  <th>Username</th>
	                  <th>Created Date</th>
	                  <th>Start date</th>
                          <th>End Date</th>
	                  <th>Delete</th>
	                </tr>
                </thead>
                <tbody>
<?php

//updates table with project results
foreach($output as $o)
{

	echo '
				<tr>
					<td>'.$o->projectID.'</td>
					<td><a href="'.base_url() .'user/projectprofile?projid='.$o->projectID.'">'.$o->projectTitle.'</a></td>
					<td>'.$o->username.'</td>
					<td>'.$o->dateCreated.'</td>
					<td>'.$o->startDate.'</td>
					<td>'.$o->endDate.'</td>
					<td><button class="btn btn-sm btn-danger" data-projid="'.$o->projectID.'" id="btnDelete"/>Delete</button></td>
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

	/////////////////////////////////////////////////////////////////////
	/**
	*** Delete project function
	**/
	/////////////////////////////////////////////////////////////////////
	$(document).ready(function() {
		$(document).on('click', "#btnDelete",function() {
			
			//project id stored in button put into a variable
			var projid = $(this).data("projid");
						
			if (confirm("Are you sure you want to delete this project?") == true){
					
				/////////////////////////////////////////////////////////////////////
				/**
				*** Post delete values to database
				**/
				/////////////////////////////////////////////////////////////////////
				$.ajax({
				url:"projects/deleteprojectadmin",
				type:"POST",
					  data:{projid:projid},
					success: function(data){
						if(data == 'done'){
							location.reload(true);
						}
						else{
							alert("Unable to delete project");
						}
						
					  }
				});
			}			  
		});
		

	});
</script>