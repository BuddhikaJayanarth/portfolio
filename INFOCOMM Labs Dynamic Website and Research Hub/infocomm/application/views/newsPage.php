<?php ;
$newsID = 0;

if(isset($_GET['id']))
{
	$newsID = $_GET['id'];
}

//query to get the events
$this->db->where('newsID =', $newsID);
$this->db->from("news");
$query = $this->db->get();
$newsItem = $query->result();

//gets the variables
foreach($newsItem as $item)
{
	$headline = $item->headline;
	$subheading = $item->subHeadline;
	$text = $item->text;
	
	$date = date('l, jS F Y', strtotime($item->date));
}
?>
  <!-- Full Width Column -->
  <div class="content-wrapper">
    
    <div style="min-height:600px; height:auto; background-attachment: fixed;
    background-position: center;
    background-repeat: no-repeat;
    background-size: cover; background-image: url('<?php echo base_url(); ?>resources/news-banner.jpg')")>
		
    	<div class="container">	
      <!-- Main content -->
      <section class="content" style="padding-top:10%; padding-bottom:10%;">
	     <div class="row">
	     	<div class="col-md-1"></div>
		     <div class="col-md-10">
			     <div class="box">
				     <div class="box-body" style="padding:7%; color:black; text-align: left">
		              	<h1><?php echo $headline ?></h1>
		              	<h3 style="font-style: italic"><?php echo $subheading ?></h3>
			            <p class="text-muted" style="font-size:15px">Published: <?php echo $date ?></p>
			            <p><?php echo $text ?></p>
			            
		            </div>
			     </div>
		     </div>
	     </div>	     
      </section>
      <!-- /.content -->
    </div>
    <!-- /.container -->
	</div>
	
    
  </div>
  <!-- /.content-wrapper -->
  

