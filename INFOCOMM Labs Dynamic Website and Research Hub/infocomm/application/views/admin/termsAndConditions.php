<?php
//queries the databse for the collaborators table
$query = $this->db->get("termsandconditions");
$about = $query->result();

$text = "";

//sets variables
foreach ($about as $row)
{
	$text = $row->text;	
}
?> 


  <!-- Content Wrapper. Contains page content -->
  <div class="content-wrapper">
    <!-- Content Header (Page header) -->
    <section class="content-header">
      <h1>Edit Terms &amp; Conditions</h1>
	  <span style="color:grey"><h6>*Text is edited on change.</h6></span>
    </section>
    <!-- Content Header (Page header) -->
    
    <!-- Main content -->
    <section class="content">
    	
      <div class="row">
        <!-- left column -->
        <div class="col-xs-12">
          <div class="box">
            <div class="box-header with-border">
              <h3 class="box-title">Terms &amp; Conditions</h3>
              
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
                    <textarea id="text" name="text" rows="10" cols="80">
						<?php echo $text; ?>
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
		CKEDITOR.replace('text');
		
		//updates text by running through the instances
		//Code adapted from https://stackoverflow.com/questions/5143516/detecting-onchange-events-from-a-ckeditor-using-jquery
		//Accessed 7/10/17
		for (var i in CKEDITOR.instances) {
			
			//sets up a listener for the text on change
		    CKEDITOR.instances["text"].on('change', function() {
		    	CKEDITOR.instances["text"].updateElement()
				var text = document.getElementById("text").value;
				
				$.post('termsAndConditions/text',{text:text}, function(result, status){
			        if (!status)
			        {
			        	alert(result);
			        }
			    });
			});
		}
	});
</script>

