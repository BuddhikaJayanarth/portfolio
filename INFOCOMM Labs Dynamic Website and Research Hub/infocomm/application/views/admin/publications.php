<?php
$this->db->select("*");
$this->db->from('user_publications');
$this->db->join('users', 'users.userID = user_publications.userID');
$query = $this->db->get();
$output = $query->result();
?> 
  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Publications
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
	                  <th>Category</th>
	                  <th>Title</th>
	                  <th>Author</th>
	                  <th>Type</th>
	                  <th>Link</th>
	                  <th>Date Published</th>
	                  <th>Delete</th>
	                </tr>
                </thead>
                <tbody>
                	
<?php
//queries the databse for the categories_project table
$query = $this->db->get("categories_project");
$pubCats = $query->result();
$catPub = '';

foreach($output as $o)
			{
				
				foreach($pubCats as $pubCat)
				{
					if ($pubCat->catID == $o->category)
					{
						$catPub = $pubCat->catName;
					}
				}
				
				$name = $o->fname . ' ' . $o->lname;
				
				echo '
					<tr>
					  <td>'.$catPub.'</td>
					  <td>'.$o->pubTitle.'</td>
					  <td>'.$name.'</td>
					  <td>'.$o->type.'</td>
					  <td>'.$o->link.'</td>
					  <td>'.$o->datePublished.'</td>
					  <td><button class="btn btn-sm btn-danger" data-id1="'.$o->pubID.'" id="btnDeletePub"/>delete</button></td>
					</tr>
					';
}
?>
	                
                </tbody>
                <tfoot>
	                <tr>
	                  <tr>
	                  <th>Category</th>
	                  <th>Title</th>
	                  <th>Author</th>
	                  <th>Type</th>
	                  <th>Link</th>
	                  <th>Date Published</th>
	                  <th>Delete</th>
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
  
<!-- includes footer -->

<!-- ./wrapper -->

<!-- jQuery 2.2.3 
<script src="<?php echo base_url(); ?>plugins/jQuery/jquery-2.2.3.min.js"></script>-->
<script src="https://ajax.googleapis.com/ajax/libs/jquery/3.2.1/jquery.min.js"></script>
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
		$(document).on('click', "#btnDeletePub",function() {
			
			var data = $(this).data("id1");
			
			var c = confirm('Are you sure you want to delete this publication?');
			
			if (c)
			{
				$.post('publications/delete',{id:data, user:"admin"}, function(result, status){
			        if (status)
			        {
			        	alert("Publication Deleted Successfully!");
			        }
			        else
			        {
			        	alert("Error!");
			        }
			    });
				location.reload(true);	
			}
			
		});
	});
</script>

