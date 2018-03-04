<?php
//query to get the information for about us
$this->db->select("*");
$this->db->from('about');
$this->db->limit(1);
$query = $this->db->get();
$about = $query->result();

foreach ($about as $row)
{
	$col1 = $row->col1;
	$col2 = $row->col2;
	$col3 = $row->col3;
	$img1 = $row->img1;
	$img2 = $row->img2;
	$img3 = $row->img3;	
}

//query to get the information for collaborators
$query = $this->db->get("collaborators");
$collaborator = $query->result();
$totalCollab = $query->num_rows();
?> 

  <!-- Full Width Column -->
  <div class="content-wrapper">
    <div class="container">
      <!-- Content Header (Page header) -->
      <section class="content-header">
        <h1>
        </h1>
      </section>

      <!-- Main content -->
      <section class="content">
        <div class="row">
        	<div align="center">
	              <div id="carousel-example-generic" class="carousel slide" data-ride="carousel">
	                <ol class="carousel-indicators">
	                  <li data-target="#carousel-example-generic" data-slide-to="0" class="active"></li>
	                  <li data-target="#carousel-example-generic" data-slide-to="1" class=""></li>
	                  <li data-target="#carousel-example-generic" data-slide-to="2" class=""></li>
	                </ol>
	                <div class="carousel-inner">
	                  <div class="item active">
	                    <img src="<?php echo $img1; ?>" alt="First slide">
	                  </div>
	                  <div class="item">
	                    <img src="<?php echo $img2; ?>" alt="Second slide">
	                  </div>
	                  <div class="item">
	                    <img src="<?php echo $img3; ?>" alt="Third slide">
	                  </div>
	                </div>
	                <a class="left carousel-control" href="#carousel-example-generic" data-slide="prev">
	                  <span class="fa fa-angle-left"></span>
	                </a>
	                <a class="right carousel-control" href="#carousel-example-generic" data-slide="next">
	                  <span class="fa fa-angle-right"></span>
	                </a>
	              </div>
            </div>
		</div>
        <!-- end of row -->
      </section>
      <section>
      	<div class="row">
	 	    <div id="aboutContent" class="col-md-4">
	   	 		<?php echo $col1; ?>
	     	</div>
	     	<div id="aboutContent" class="col-md-4">
	   	 		<?php echo $col2; ?>
	     	</div>
	     	<div id="aboutContent" class="col-md-4">
	   	 		<?php echo $col3; ?>
	     	</div>
	     </div>
      </section>
      <!-- /.content -->
      
      <!-- Collaborators -->
      <section class="content">
        <div class="row">
        	<div class="col-md-12" align="center"><h1 class="center-block">Our Collaborators</h1></div>
    	</div>
        <div class="row">
        	<div align="center">
	              <div id="carousel-collab" class="carousel slide" data-ride="carousel">
	              	<ol class="carousel-indicators">
              		<?php
	              	$count = 0;
	              	while($count < $totalCollab)
					{
						if($count == 0) {
							echo '<li data-target="#carousel-collab" data-slide-to="'.$count.'" class="active"></li>';
						}
						else {
							echo '<li data-target="#carousel-collab" data-slide-to="'.$count.'"></li>';
						}	
						$count++;
					}
	              	?>
	              	</ol>
    				<div class="carousel-inner">
	                <?php
	              	$count = 0;
	              	foreach ($collaborator as $collab)
					{
						$name = $collab->affiliation;
						$dept = $collab->department;
						$website = $collab->website;
						$logo = $collab->logo;
						
						if($count == 0) {
							echo '<div class="item active"><a href="'.$website.'">
				                    <img src="'.$logo.'" alt="Collaborator"></a>';
						}
						else {
							echo '<div class="item"><a href="'.$website.'">
				                    <img src="'.$logo.'" alt="Collaborator"></a>';
						}
						echo '<div class="caption">
							    <h3>'.$name.'</h3>
							    <p>'.$dept.'</p>
							  </div></div>';
						$count++;	
					}
	              	?>
	                </div>
	                <a class="left carousel-control" href="#carousel-collab" data-slide="prev">
	                  <span class="fa fa-angle-left"></span>
	                </a>
	                <a class="right carousel-control" href="#carousel-collab" data-slide="next">
	                  <span class="fa fa-angle-right"></span>
	                </a>
	              </div>
            </div>
		</div>
        <!-- end of row -->
      </section>
      
    </div>
    <!-- /.container -->
  </div>
  <!-- /.content-wrapper -->