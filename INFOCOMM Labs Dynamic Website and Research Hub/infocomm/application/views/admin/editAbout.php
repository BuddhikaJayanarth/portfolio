<?php
//queries the databse for the collaborators table
$query = $this->db->get("about");
$about = $query->result();

//sets variables
foreach ($about as $row)
{
	$col1 = $row->col1;
	$col2 = $row->col2;
	$col3 = $row->col3;
	$img1 = $row->img1;
	$img2 = $row->img2;
	$img3 = $row->img3;	
}
?> 


  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>Edit About Us</h1>
	  <span style="color:grey"><h6>*Text is edited on change.</h6></span>
    </section>
    <!-- Content Header (Page header) -->
    
    <!-- Main content -->
    <section class="content">
    	
	 <div class="row">
  	  	<div class="col-md-4">
  	  	  <!-- general form elements -->
          <div class="box">
          	<div class="box-header with-border">
	          <h3 class="box-title">Slider Image 1</h3>
	        </div>
          	<div class="box-body">
          	<div><img id="image1" class="img-responsive center-block" src="<?php echo $img1 ?>" /></div><br />
            <!-- form start -->
            <form enctype="multipart/form-data" id="uploadImg1">
                        <input name="baseURL" id="baseURL" type="hidden" value="<?php echo base_url() ?>" />
          		<div class="form-group pull-right">
          		  	<span style="color:grey"><h6>Please upload an image</h6>
          			<h6>of dimensions 1000x400</h6>
          			<h6>and maximum size 2 MB.</h6></span>
          		  <input type="hidden" name="name" id="name" value="img1" />
			 	  <input type="file" name="img" id="img" required="required" />
			 	  <br />
			 	  <button type="submit" id="btnUploadImg1" class="btn btn-success">Edit</button>
                </div>
              </div>
            </form>
            <!-- form end -->
          </div>
          <!-- /.box -->
  	  	</div>
  	  	<div class="col-md-4">
  	  	  <!-- general form elements -->
          <div class="box">
          	<div class="box-header with-border">
	          <h3 class="box-title">Slider Image 2</h3>
	        </div>
          	<div class="box-body">
          	<div><img id="image2" class="img-responsive center-block" src="<?php echo $img2 ?>" /></div><br />
            <!-- form start -->
            <form enctype="multipart/form-data" id="uploadImg2">
            		<input name="baseURL" id="baseURL" type="hidden" value="<?php echo base_url() ?>" />
          		<div class="form-group pull-right">
			 	  	<span style="color:grey"><h6>Please upload an image</h6>
          			<h6>of dimensions 1000x400</h6>
          			<h6>and maximum size 2 MB.</h6></span>
			 	  <input type="hidden" name="name" id="name" value="img2" />
			 	  <input type="file" name="img" id="img" required="required" />
			 	  <br />
			 	  <button type="submit" id="btnUploadImg2" class="btn btn-success">Edit</button>
                </div>
              </div>
            </form>
            <!-- form end -->
          </div>
          <!-- /.box -->
  	  	</div>
  	  	<div class="col-md-4">
  	  	  <!-- general form elements -->
          <div class="box">
          	<div class="box-header with-border">
	          <h3 class="box-title">Slider Image 3</h3>
	        </div>
          	<div class="box-body">
          	<img id="image3" class="img-responsive center-block" src="<?php echo $img3 ?>" /><br />
            <!-- form start -->
            <form enctype="multipart/form-data" id="uploadImg3">
            		<input name="baseURL" id="baseURL" type="hidden" value="<?php echo base_url() ?>" />
          		<div class="form-group pull-right">
          			<span style="color:grey"><h6>Please upload an image</h6>
          			<h6>of dimensions 1000x400</h6>
          			<h6>and maximum size 2 MB.</h6></span>
          			<input type="hidden" name="name" id="name" value="img3" />
			 	  <input type="file" name="img" id="img" required="required" />
			 	  <br />
			 	  <button type="submit" id="btnUploadImg3" class="btn btn-success">Edit</button>
                </div>
              </div>
            </form>
            <!-- form end -->
          </div>
          <!-- /.box -->
  	  	</div>
  	  </div>
	  <!-- /.row -->
      <div class="row">
        <!-- left column -->
        <div class="col-md-4">
          <div class="box">
            <div class="box-header with-border">
              <h3 class="box-title">Content for column 1</h3>
              
              <!-- tools box -->
              <div class="pull-right box-tools">
                <button type="button" class="btn btn-info btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i></button>
              </div>
              <!-- /. tools -->
            </div>
            <!-- /.box-header -->
            <div class="box-body pad">
              <form>
                    <textarea id="col1" name="col1" rows="10" cols="80">
						<?php echo $col1 ?>
                    </textarea>
              </form>
            </div>
          </div>
          <!-- /.box -->
        </div>
  	  
  	    <!-- middle column -->
        <div class="col-md-4">
          <div class="box">
            <div class="box-header with-border">
              <h3 class="box-title">Content for column 2</h3>
              
              <!-- tools box -->
              <div class="pull-right box-tools">
                <button type="button" class="btn btn-info btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i></button>
              </div>
              <!-- /. tools -->
            </div>
            <!-- /.box-header -->
            <div class="box-body pad">
              <form>
                    <textarea id="col2" name="col2" rows="10" cols="80">
						<?php echo $col2 ?>
                    </textarea>
              </form>
            </div>
          </div>
          <!-- /.box -->
        </div>
      
        <!-- right column -->
        <div class="col-md-4">
          <div class="box">
            <div class="box-header with-border">
              <h3 class="box-title">Content for column 3</h3>
              
              <!-- tools box -->
              <div class="pull-right box-tools">
                <button type="button" class="btn btn-info btn-sm" data-widget="collapse" data-toggle="tooltip" title="Collapse">
                  <i class="fa fa-minus"></i></button>
              </div>
              <!-- /. tools -->
            </div>
            <!-- /.box-header -->
            <div class="box-body pad">
              <form>
                    <textarea id="col3" name="col3" rows="10" cols="80">
						<?php echo $col3 ?>
                    </textarea>
              </form>
            </div>
          </div>
          <!-- /.box -->
        </div>
        
      </div>
      <!-- /.row -->
    </section>
    <!-- /.content -->
    
  </div>
  <!-- /.content-wrapper -->

<!-- jQuery 2.2.3 -->
<script src="<?php echo base_url(); ?>plugins/jQuery/jquery-2.2.3.min.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="<?php echo base_url(); ?>bootstrap/js/bootstrap.min.js"></script>
<!-- AdminLTE App -->
<script src="<?php echo base_url(); ?>dist/js/app.min.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="<?php echo base_url(); ?>dist/js/demo.js"></script>
<!-- CK Editor -->
<script src="https://cdn.ckeditor.com/4.5.7/standard/ckeditor.js"></script>

<!-- page script -->
<script>
	$(document).ready(function() {
		
		//initializes the CK editor instances
		CKEDITOR.replace('col1');
		CKEDITOR.replace('col2');
		CKEDITOR.replace('col3');
		
		//Edits img 1
		$(document).on('submit', "#uploadImg1",function(e) {
			e.preventDefault();
			
			$.ajax({
				type: "POST",
				url: "editAbout/image",
				data: new FormData(this),
				processData: false,
				cache: false,
				contentType: false,				
				success: function(data) {
					location.reload(true);
				}
			});
		});
		//Edits img 2
		$(document).on('submit', "#uploadImg2",function(e) {
			e.preventDefault();
			
			$.ajax({
				type: "POST",
				url: "editAbout/image",
				data: new FormData(this),
				processData: false,
				cache: false,
				contentType: false,				
				success: function(data) {	
					location.reload(true);
				}
			});
		});
		//Edits img 3
		$(document).on('submit', "#uploadImg3",function(e) {
			e.preventDefault();
			
			$.ajax({
				type: "POST",
				url: "editAbout/image",
				data: new FormData(this),
				processData: false,
				cache: false,
				contentType: false,				
				success: function(data) {
					location.reload(true);
				}
			});
		});
		
		//updates text by running through the instances
		//Code adapted from https://stackoverflow.com/questions/5143516/detecting-onchange-events-from-a-ckeditor-using-jquery
		//Accessed 7/10/17
		for (var i in CKEDITOR.instances) {
			
			//sets up a listener for col 1 on change
		    CKEDITOR.instances["col1"].on('change', function() {
		    	CKEDITOR.instances["col1"].updateElement()
				var text = document.getElementById("col1").value;
				var col = "col1";
				
				$.post('editAbout/text',{text:text, col:col}, function(result, status){
			        if (!status)
			        {
			        	alert(result);
			        }
			    });
			});
			
			//sets up a listener for col 2 on change
			CKEDITOR.instances["col2"].on('change', function() {
		    	CKEDITOR.instances["col2"].updateElement()
				var text = document.getElementById("col2").value;
				var col = "col2";
				
				$.post('editAbout/text',{text:text, col:col}, function(result, status){
			        if (!status)
			        {
			        	alert(result);
			        }
			    });
			});
			
			//sets up a listener for col 3 on change
			CKEDITOR.instances["col3"].on('change', function() {
		    	CKEDITOR.instances["col3"].updateElement()
				var text = document.getElementById("col3").value;
				var col = "col3";
				
				$.post('editAbout/text',{text:text, col:col}, function(result, status){
			        if (!status)
			        {
			        	alert(result);
			        }
			    });
			});
		}
	});
</script>

