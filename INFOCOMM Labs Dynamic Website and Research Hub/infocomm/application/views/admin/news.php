<?php
$this->db->order_by('date', 'DESC');
$query = $this->db->get('news');
$newsList = $query->result();
?> 


  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        News
      </h1>
    </section>

    <!-- Main content -->
    <section class="content">
      <div class="row">
        <div class="col-xs-12">
          <div class="box">
            <!-- /.box-header -->
            <div class="box-body"><div class="table table-responsive">
              <table class="eventTable table table-bordered table-striped">
                <thead>
	                <tr>
	                  <th>Date Published</th>
	                  <th>Heading</th>
	                  <th>Subheading</th>
	                  <th>Edit</th>
	                  <th>Delete</th>
	                </tr>
                </thead>
                <tbody>
                	
<?php
foreach($newsList as $item)
{		
	 echo'          <tr>
	                  <td>'.$item->date.'</td>
	                  <td>'.$item->headline.'</td>
	                  <td>'.$item->subHeadline.'</td>
	                  <td><button class="btn btn-sm btn-warning" data-id="'.$item->newsID.'" data-head="'.$item->headline.'" data-sub="'.$item->subHeadline.'" data-text="'.htmlentities($item->text).'" id="btnEdit" />edit</button></td>
	                  <td><button class="btn btn-sm btn-danger" data-id="'.$item->newsID.'" id="btnDelete"/>delete</button></td>
	                </tr>
	      ';          
}
?>
                </tbody>
                <tfoot>
	                <tr>
	                  <th>Date Published</th>
	                  <th>Heading</th>
	                  <th>Subheading</th>
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
  

<!-- edit-modal -->
<div class="example-modal" >
	<div class="modal" id="modalEditNews">
	  <div class="modal-dialog">
	    <div class="modal-content">
	      <div class="modal-header">
	        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
	          <span aria-hidden="true">&times;</span></button>
	        <h4 class="modal-title">Edit News</h4>
	      </div>
	      <form id="frmEditNews" enctype="multipart/form-data">
	      	<input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />
	      <div class="modal-body">
	      	<div class="row">
	      		<div class="col-xs-12">
	                
	                <div class="form-group">
	                  <input type="text" class="form-control" name="heading" id="heading" placeholder="Heading">
	                </div>
	                
	                <div class="form-group">
	                  <input type="text" class="form-control" name="subheading" id="subheading" placeholder="Sub Heading">
	                </div>
	                
	              	<div class="form-group">
						<textarea id="text" name="text" rows="12" cols="150" placeholder="Description"></textarea>
	                </div>
	      		</div>
	      	</div>
	      </div>
	      <input type="hidden" id="id" name="id" />
	      <div class="modal-footer">
	        <button type="button" class="btn btn-default pull-left" data-dismiss="modal">Close</button>
	        <button type="submit" id="btnEditNews" class="btn btn-success">Save Changes</button>
	      </div>
	      </form>
	    </div>
	    <!-- /.modal-content -->
	  </div>
	  <!-- /.modal-dialog -->
	</div>
	<!-- /.modal -->
</div>
<!-- /.edit-modal -->    
   
    
  </div>
  <!-- /.content-wrapper -->
  
<!-- includes footer -->

<!-- ./wrapper -->

<!-- jQuery 2.2.3 -->
<script src="<?php echo base_url(); ?>plugins/jQuery/jquery-2.2.3.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="<?php echo base_url(); ?>bootstrap/js/bootstrap.min.js"></script>
<!-- DataTables -->
<script src="<?php echo base_url(); ?>plugins/datatables/jquery.dataTables.min.js"></script>
<script src="<?php echo base_url(); ?>plugins/datatables/dataTables.bootstrap.min.js"></script>
<!-- AdminLTE App -->
<script src="<?php echo base_url(); ?>dist/js/app.min.js"></script>
<!-- CK Editor -->
<script src="https://cdn.ckeditor.com/4.5.7/standard/ckeditor.js"></script>
<!-- page script -->
<script>
	$(function () {
	    $('.eventTable').DataTable({
	      "paging": true,
	      "lengthChange": true,
	      "searching": true,
	      "ordering": false,
	      "info": false,
	      "autoWidth": true
	    });
	    
		//initializes the CK editor instance
		CKEDITOR.replace('text');
	});
	
	$(document).ready(function() {
		
		//delete news
		$(document).on('click', "#btnDelete",function() {
			
			var data = $(this).data("id");
			
			var c = confirm('Are you sure you want to delete this item?');
			
			if (c)
			{
				$.post('news/delete',{id:data}, function(result, status){
			        if (status)
			        {
			        	alert("Item Deleted Successfully!");
			        	window.location = $("#baseURL").val() + "admin/news";
			        }
			        else
			        {
			        	alert("Error Deleting! Please try again.");
			        }
			    });
			}
			
		});
		
		var imageID = null;
		
		//Edit Modal
		$(document).ready(function() {
			$(document).on('click', "#btnEdit",function() {
				
				//gets the data
				var id = $(this).data("id");
				var head = $(this).data("head");
				var sub = $(this).data("sub");
				var text = $(this).data("text");
		
				//passes the value to the modal
				$("#id").val(id);
				CKEDITOR.instances.text.setData(text); 
				$("#subheading").val(sub);
				$("#heading").val(head);
				
				//shows the modal
				$('#modalEditNews').modal('show');
			});
		});
		
		//Edit News function
		$(document).on('submit', "#frmEditNews",function(e) {
			
			e.preventDefault();
							
			var c = confirm('Are you sure you want to save these changes?');
			
			if (c)
			{
				$.ajax({
					type: "POST",
					url: "news/edit",
					data: new FormData(this),
					processData: false,
					cache: false,
					contentType: false,				
					success: function(result, status) {
					        if (status)
					        {
					        	alert("Changes Successful!");
					        	window.location = $("#baseURL").val() + "admin/news";
					        }
					        else
					        {
					        	alert("Error!");
					        }
					}
				});
			}
		});
	});
</script>
