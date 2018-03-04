  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Add News
      </h1>
    </section>
	<!-- Main content -->
    <section class="content">
      <div class="row">
        <!-- left column -->
        <div class="col-md-12">
          <!-- general form elements -->
          <div class="box box-success">
            <div class="box-header with-border">
              <h3 class="box-title">Add News</h3>
            </div>    
		    <form id="frmAddNews" enctype="multipart/form-data">
		      <div class="box-body">
		      	<div class="row">
		      		<div class="col-xs-12">
		                <input id="baseURL" name="baseURL" type="hidden" value="<?php echo base_url() ?>" />
		                
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
		      <div class="box-footer">
		        <button type="submit" id="btnAdd" class="btn btn-success">Add</button>
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
		//initializes the CK editor instance
		CKEDITOR.replace('text');
		
		//Add News function
		$(document).on('submit', "#frmAddNews",function(e) {
			e.preventDefault();
			
			$.ajax({
				type: "POST",
				url: "addNews/add",
				data: new FormData(this),
				processData: false,
				cache: false,
				contentType: false,				
				success: function(result, status) {
			        if (status)
			        {
			        	alert("Added Successfully!");
			        	window.location = $("#baseURL").val() + "admin/news";
			        }
			        else
			        {
			        	alert("Error!");
			        }
				}
			});
		});
	});
</script>
