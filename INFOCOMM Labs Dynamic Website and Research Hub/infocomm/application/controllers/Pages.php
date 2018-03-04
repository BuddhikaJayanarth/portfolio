<?php
class Pages extends CI_Controller{
	
	public function homepage($page = 'index'){
		$this->load->library('session');
		
		if ( ! file_exists(APPPATH.'views/'.$page.'.php'))
        {
                // Whoops, we don't have a page for that!
                show_404();
        }

        $data['title'] = ucfirst($page); // Capitalize the first letter
		
        $this->load->view('templates/header', $data);
		//$this->load->view('templates/sidebarAdmin', $data);
        $this->load->view($page, $data);
        $this->load->view('templates/footer', $data);
	}
	
	public function loadAdmin($page = 'login'){
		$this->load->library('session');
		
		if ( ! file_exists(APPPATH.'views/admin/'.$page.'.php'))
        {
                // Whoops, we don't have a page for that!
                show_404();
        }
		
		$data['title'] = ucfirst($page);
		$this->load->view('admin/'.$page, $data);
	}
	
	public function loadAdminPage($page = ''){
		$this->load->library('session');
		if ( ! file_exists(APPPATH.'views/admin/'.$page.'.php'))
        {
                // Whoops, we don't have a page for that!
                show_404();
        }
		
		$data['title'] = ucfirst($page);
		$this->load->view('admin_templates/topAdmin', $data);
		$this->load->view('admin_templates/sidebarAdmin', $data);
		$this->load->view('admin/'.$page, $data);
		$this->load->view('admin_templates/footerAdmin', $data);
		
	}
	
	public function loadUsers($page = ''){
		$this->load->library('session');
		
		if ( ! file_exists(APPPATH.'views/user/'.$page.'.php'))
        {
                // Whoops, we don't have a page for that!
                show_404();
        }
		$data['title'] = ucfirst($page);
		$pagename = array('login','register','security','logout', 'activate', 'forgot','reset');
		if(in_array($page, $pagename)){
			$this->load->view('user/'.$page, $data);
		}else{
			$this->load->view('templates/header', $data);
			$this->load->view('user/'.$page, $data);
			$this->load->view('templates/footer', $data);
		}
		
	}
	
	public function loadPages($page = ''){
		$this->load->library('session');
		if ( ! file_exists(APPPATH.'views/'.$page.'.php'))
        {
                // Whoops, we don't have a page for that!
                show_404();
        }
		$data['title'] = ucfirst($page);
		$pagename = array('activate','Terms-Condition');
		if(in_array($page, $pagename)){
			$this->load->view($page, $data);
		}else{
			$this->load->view('templates/header', $data);
			$this->load->view($page, $data);
			$this->load->view('templates/footer', $data);
		}
	}
	
}
?>
