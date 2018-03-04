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

    <section class="content">
    	
      <div class="row">
        <!-- left column -->
        <div class="col-md-6">
          <!-- general form elements -->
          <div class="box box-success">
          	<div class="box-header with-border">
              <h3 class="box-title">Add Collaborator</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
            <form name="addCollab" id="addCollab" enctype="multipart/form-data">
              <div class="box-body">
              	
              	<input name="baseURL" id="baseURL" type="hidden" value="<?php echo base_url() ?>" />
                <input type="hidden" id="imageID" name="imageID">
                
                <div class="form-group">
                  <input type="text" class="form-control" name="affiliation" placeholder="Affiliation" required="required">
                </div>
                
                <div class="form-group">
                  <input type="text" class="form-control" name="department" placeholder="Department" required="required">
                </div>
                
                <div class="form-group">
                  <input type="text" class="form-control" name="contactPerson" placeholder="Contact Person" required="required">
                </div>
                
                <div class="form-group">
                  <input type="text" class="form-control" name="website" placeholder="Website" required="required">
                </div>
                
                <div class="form-group">
                  <label for="logo">Upload Logo</label>
                  <input type="file" id="logo" name="logo">

                  <p class="help-block">You can only upload jpg and png images.</p>
                </div>
                
              <div class="box-footer">
                <button type="submit" id="btnAddCollab" class="btn btn-success">Add</button>
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
	$(document).ready(function() {
		
		//Add collaborators method
		//Method checks if it exists in the database and enters if not
		$(document).on('submit', '#addCollab',function(e) {
			
			e.preventDefault();
			
			$.ajax({
				url: "addCollaborators/new",
				type: "POST",
				data: new FormData(this),
				contentType: false,
				cache: false,
				processData: false,
				success: function(result, status){
		        	if(result == "true")
		        	{
		        		alert("Sorry this collaborator already exists");
		        	}
		        	else if(result == "There was an error adding this collaborator. Please try again")
		        	{
		        		alert(result);
		        	}
					else
					{
						//uploads image
						imageID = result;
						$("#imageID").val(imageID);
						//creates form object 
						var form = $('#addCollab')[0];
						var formData = new FormData(form);
						
						$.ajax({
							url: "addCollaborators/logo",
							type: "POST",
							data: formData,
							contentType: false,
							cache: false,
							processData: false,
							success: function(result, status){
								if(result == "Success")
								{
									alert("Added Successfully!");
								}
								else
								{
									alert(result);
								}
							}					
						});
					}
					
					window.location = $("#baseURL").val() + "admin/collaborators";
				}
				
			});
		});
	});
</script>