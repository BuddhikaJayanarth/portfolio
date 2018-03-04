

  <!-- Full Width Column -->
  <div class="content-wrapper">

<link rel="stylesheet" href="<?php echo base_url() ?>dist/css/meet_team_css.css">

    <div class="container">
    <br>

     <div class="row">
     
     <div class="col">
     
     <div class="box box-success">
     <div class="box-header with-border">
	     <h1 style="color:#00a65a; text-align:center" >Infocomm Team</h1>  
     </div>   
     <div class="box-body">


<!-- ~~~=| team container start |=~~~ -->
<div class="container">
<h3 style="color:#00a65a" align="center">Lab Directors</h3>

		<?php
		
			$this->db->select('*');
			$this->db->from('users');
			$this->db->where('designation', "Lab Director");
			$query = $this->db->get();
			$output = $query->result();
			//$output = $query->row();			
			foreach ($output as $o)
			{
				echo '
				<div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="'.base_url().'/resources/profile_image/'o'" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>'.$o->fname.' '.$o->lname.' </h2>
        <p class="title">CEO &amp; Founder</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>
				';
			}
		?>
    
  
</div> 
<!-- ~~~=| team container END |=~~~ -->

<!-- ~~~=| team container start |=~~~ -->
<div class="container">
<br>
<h3 style="color:#00a65a" align="center">Visiting Professors</h3>
  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img1.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Jackie Reiner </h2>
        <p class="title">CEO &amp; Founder</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img2.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Mike Ross</h2>
        <p class="title">Art Director</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img2.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Mike Ross</h2>
        <p class="title">Art Director</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>
    
  
</div> 
<!-- ~~~=| team container END |=~~~ -->

<!-- ~~~=| team container start |=~~~ -->
<div class="container">
<br>
<h3 style="color:#00a65a" align="center">Post Dosctorate</h3>
  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img1.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Jackie Reiner </h2>
        <p class="title">CEO &amp; Founder</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img2.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Mike Ross</h2>
        <p class="title">Art Director</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img2.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Mike Ross</h2>
        <p class="title">Art Director</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>
    
  
</div> 
<!-- ~~~=| team container END |=~~~ -->

<!-- ~~~=| team container start |=~~~ -->
<div class="container">
<br>
<h3 style="color:#00a65a" align="center">Phd Students</h3>
  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img1.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Jackie Reiner </h2>
        <p class="title">CEO &amp; Founder</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img2.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Mike Ross</h2>
        <p class="title">Art Director</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img2.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Mike Ross</h2>
        <p class="title">Art Director</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>
    
  
</div> 
<!-- ~~~=| team container END |=~~~ -->

<!-- ~~~=| team container start |=~~~ -->
<div class="container">
<br>
<h3 style="color:#00a65a" align="center">Master Students</h3>
  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img1.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Jackie Reiner </h2>
        <p class="title">CEO &amp; Founder</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img2.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Mike Ross</h2>
        <p class="title">Art Director</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img2.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Mike Ross</h2>
        <p class="title">Art Director</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>
    
  
</div> 
<!-- ~~~=| team container END |=~~~ -->

<!-- ~~~=| team container start |=~~~ -->
<div class="container">
<br>
<h3 style="color:#00a65a" align="center">Engineers</h3>
  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img1.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Jackie Reiner </h2>
        <p class="title">CEO &amp; Founder</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img2.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Mike Ross</h2>
        <p class="title">Art Director</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img2.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Mike Ross</h2>
        <p class="title">Art Director</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>
  
    <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img1.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Jackie Reiner </h2>
        <p class="title">CEO &amp; Founder</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img2.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Mike Ross</h2>
        <p class="title">Art Director</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>
  
    <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img1.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Jackie Reiner </h2>
        <p class="title">CEO &amp; Founder</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>

  <div class="column">
    <div class="card">
		<div class="center-cropped">
          <img src="<?php echo base_url() ?>dist/img/teamimages/img2.jpg" alt="Mike" style="width:100%">      
		</div>
      <div class="container">
        <h2>Mike Ross</h2>
        <p class="title">Art Director</p>
        <p>Some text that describes me lorem ipsum ipsum lorem.</p>
        <p>example@example.com</p>

      </div>
    </div>
  </div>
    
  
</div> 
<!-- ~~~=| team container END |=~~~ -->

     </div>
     </div>
     
     </div>
     
     </div>
     
     </div>

  </div>
  <!-- /.content-wrapper -->