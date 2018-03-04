<?php
//queries the databse for the contact details
$query = $this->db->get("contact");
$output = $query->result();
foreach($output as $o){
$contact = $o;	
}

?>

<footer class="footer" style="background-color:black">
	<div class="container" >
		<div class="row">
			<div class="col-md-4">
				<p><img src="<?php echo base_url() ?>resources/logo_png.png" width="300"/></p>
				<p>Infocomm is a research lab associated with Tomsk Polytechnic University.</p>
			</div>
			<div class="col-md-4">
				<h3>Navigation</h3>
				<p><a href="<?php echo base_url() ?>index">Home</a></p>
				<p><a href="<?php echo base_url() ?>projects">Projects</a></p>
				<p><a href="<?php echo base_url() ?>viewPublications">Publications</a></p>
				<p><a href="<?php echo base_url() ?>about">About Us</a></p>
				<p><a href="<?php echo base_url() ?>contact">Contact</a></p>
			</div>
			<div class="col-md-4">
				<h3>Contact</h3>
				<p class="silver"><?php echo $contact->address ?></p>
				<p class="silver"><?php echo $contact->phone ?></p>
				<p class="silver"><?php echo $contact->email ?></p>
			</div>			
		</div>
        <h6 style="color:black;">Developed by Brite Eguavoen, Buddhika Badalge, Fatema Shabbir</h6>
	</div>
</footer>

<!-- ~~~=| Footer END |=~~~ --> 


<!-- jQuery 2.2.3 -->
<script src="<?php echo base_url() ?>plugins/jQuery/jquery-2.2.3.min.js"></script>
<script src="https://code.jquery.com/ui/1.12.1/jquery-ui.js"></script>
<!-- Bootstrap 3.3.6 -->
<script src="<?php echo base_url() ?>bootstrap/js/bootstrap.min.js"></script>
<!-- SlimScroll -->
<script src="<?php echo base_url() ?>plugins/slimScroll/jquery.slimscroll.min.js"></script>
<!-- FastClick -->
<script src="<?php echo base_url() ?>plugins/fastclick/fastclick.js"></script>
<!-- AdminLTE App -->
<script src="<?php echo base_url() ?>dist/js/app.min.js"></script>
<!-- Scripts -->
<script src="<?php echo base_url() ?>dist/js/function.js"></script>
<script src="<?php echo base_url() ?>dist/js/project.js"></script>
<script src="<?php echo base_url() ?>dist/js/profile_async.js"></script>
<script src="<?php echo base_url() ?>dist/js/search.js"></script>
<script src="<?php echo base_url() ?>dist/js/sort.js"></script>
<script src="<?php echo base_url() ?>dist/js/jobScript.js"></script>
<script src="<?php echo base_url() ?>dist/js/action.js"></script>
<!-- AdminLTE for demo purposes -->
<script src="<?php echo base_url() ?>dist/js/demo.js"></script>
<!-- DataTables -->
<script src="<?php echo base_url(); ?>plugins/datepicker/bootstrap-datepicker.js"></script>
<script src="<?php echo base_url(); ?>plugins/datatables/jquery.dataTables.min.js"></script>
<script src="<?php echo base_url(); ?>plugins/datatables/dataTables.bootstrap.min.js"></script>
<script>
  $(function () {
    $('.eventTables').DataTable({
      "paging": true,
      "lengthChange": false,
      "searching": false,
      "ordering": false,
      "info": false,
      "autoWidth": false,
      "pageLength": 2
    });
$('.newsTables').DataTable({
      "paging": true,
      "lengthChange": false,
      "searching": false,
      "ordering": false,
      "info": false,
      "autoWidth": false,
      "pageLength": 12
    });
  });
</script>
</body>
</html>
