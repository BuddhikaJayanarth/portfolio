<?php
//queries the databse for the project_categories table
$query = $this->db->get("categories_project");
$output = $query->result();
//initialises array to hold category names
$catNameArray = array();
//sets count to print the numbers
$count = 0;
?> 

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Project/Publication Categories
      </h1>
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="row">
        <div class="col-xs-12">

          <div class="box">
            <!-- /.box-header -->
            <div class="box-body">
              <table id="example1" class="table table-bordered table-striped">
              	<input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />
                <thead>
	                <tr>
	                  <th>#</th>
	                  <th>Name</th>
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
	
	//filters out categories named uncategorized 
	if ($o->catName != "uncategorized")
	{
		//adds the the catName array that is used in the jQuery method to add new category
		array_push($catNameArray, $o->catName);
		
		//prints out rows
		echo '
					<tr>
						<td>'.$count.'</td>
						<td>'.$o->catName.'</td>
						<td><button class="btn btn-sm btn-danger" data-id="'.$o->catID.'" id="btnDeleteCat"/>delete</button></td>
					</tr>
		';	
	}            
}
?>
                </tbody>
                <tfoot>
	                <tr>
	                  <tr>
	                  <th>#</th>
	                  <th>Name</th>
	                  <th>Delete</th>
	                </tr>
                </tfoot>
              </table>
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
    
    
    <section class="content">
    	
      <div class="row">
        <!-- left column -->
        <div class="col-md-6">
          <!-- general form elements -->
          <div class="box box-success">
          	<div class="box-header with-border">
              <h3 class="box-title">Add Category</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
            <form name="addCat">
              <div class="box-body">
                
                <div class="form-group">
                  <input type="text" name="name" id="name" class="form-control" placeholder="Name" required>
                </div>
                
              <div class="box-footer">
                <button id="btnAddCat" class="btn btn-success">Add</button>
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
	//Delete Category
	$(document).ready(function() {
		$(document).on('click', "#btnDeleteCat",function() {
			
			//gets the id of the category to be deleted
			var data = $(this).data("id");
			
			var c = confirm('Are you sure you want to delete this category?');
			
			if (c)
			{
				//posts the value to be deleted to the controller
				$.post('categories/delete',{id:data}, function(result, status){
			        if (status)
			        {
			        	window.location = $("#baseURL").val() + "admin/categories";
			        }
			        else
			        {
			        	alert("Error!");
			        }
			    });
			}
		});
		
		//Method checks if it exists in the database and enters if not
		$(document).on('click', "#btnAddCat",function() {
			//sets&gets the length of the category name array
			<?php $catLength = count($catNameArray);?>
			var count = <?php echo $catLength ?>;
			
			//gets the php cat anem array and assigns it to the jquery names array
			var namesArray = <?php echo json_encode($catNameArray) ?>;
			
			//gets the name of the new category
			var name = document.getElementById("name").value;
			
			var x = 0;
			var isThere = false;
			
			//checks if the name already exists and alert an error if it does
			while (x < count)
			{
				if (namesArray[x] == name)
				{
					alert("Sorry this name already exists!");
					isThere = true;
				}
				x++;
			}
			
			//posts to the controller if the name does not exist
			if(!isThere && name !== '')
			{
				$.post('categories/new',{name:name}, function(result, status){
			        if (status)
			        {
			        	window.location = $("#baseURL").val() + "admin/categories";
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