 <!-- Content Wrapper. Contains page content -->
<div class="content-wrapper">
 <form enctype="multipart/form-data" id="uploadForm"><!------I changed the form attribute from name to id--->
 	<input type="text" name="id" id="id" value="2" required="required" />
 	<input type="file" name="newImg" id="newImg" required="required" />
 	<button type="submit" id="btnUpload" class="btn btn-success">Upload</button>
 </form>
</div>

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
		$(document).on('submit', "#uploadForm",function(e) {
			e.preventDefault();
			
			//var form = new FormData(this); // I commented this
			
			$.ajax({
				type: "POST",
				url: "test/t",
				data: new FormData(this), //Put it here
				processData: false,
				cache: false,
				contentType: false,				
				success: function(data) {
					alert(data);
				}
			});
		});
	});
	
</script>