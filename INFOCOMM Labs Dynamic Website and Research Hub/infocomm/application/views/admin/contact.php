<?php
//queries the databse for the contact details
$query = $this->db->get("contact");
$output = $query->result();
$o1;
foreach($output as $o){
$o1 = $o;	
}

			if(count($_GET)>0) {
     			echo '<script type="text/javascript">window.location = "http://localhost/infocomm/index.php/admin/contact"</script>';
			}

?> 

  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>
        Contact Us
      </h1>
    </section>

    <!-- Main content -->

    <section class="content">
    	
      <div class="row">
        <!-- left column -->
        <div class="col-md-10">
          <!-- general form elements -->
          <div class="box box-success">
          	<div class="box-header with-border">
              <h3 class="box-title">Edit text on the Contact Us page</h3>
            </div>
            <!-- /.box-header -->
            <!-- form start -->
            <form id="editcontactform">
              <div class="box-body">
                
                <div class="form-group">
                  <input type="text" class="form-control" name="headertext" placeholder="Contact Header Text" required="required" value="<?php echo $o1->contactheader;?>">
                </div>
                
                <div class="form-group">
                  <input type="text" class="form-control" name="bodytext" placeholder="Body Text" required="required" value="<?php echo $o1->contactbody;?>">
                </div>
                
                <div class="form-group">
                  <textarea rows="5" class="form-control" name="address" placeholder="Contact Address" required="required" ><?php echo $o1->address;?></textarea>
                </div>
                
                <div class="form-group">
                  <input type="text" class="form-control" name="phone" placeholder="Phone Number" required="required" value="<?php echo $o1->phone;?>">
                </div>
                
				<div class="form-group">
                                <div class="form-group">
                  <input type="text" class="form-control" name="email" placeholder="Email Address" required="required" value="<?php echo $o1->email;?>">
                </div>
                
				<div class="form-group">
                	<label class="control-label col-sm-3">Google Maps Coordinate</label>
                <div class="col-sm-4">
                                <input type="text" class="form-control pull-right" name="xcord" placeholder="X-coordinate" value="<?php echo $o1->xcoordinate;?>"/>
                            </div>
                            <div class="col-sm-4">
                                <input type="text" class="form-control pull-right" name="ycord" placeholder="Y-coordinate" value="<?php echo $o1->ycoordinate;?>"/>
                            </div>
                 </div>
                </div>
              <div class="box-footer">
                <button type="submit" id="btneditcontact" class="btn btn-success">Save Changes</button>
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
	$(document).ready(function() {
				
		//Add collaborators method
		//Method checks if it exists in the database and enters if not
		$(document).on('submit', "#editcontactform",function() {
			
			var formdata = new FormData(this);

			$.ajax({
				type: "POST",
				url: "contact/editcontact",
				data: formdata,
				processData: false,
				contentType: false,
				success: function(data){
					if(data =="done"){
						alert("Edited Contact Us");
					}
				}
				
			});
			
		});
	});
</script>