import React from 'react';
import { connect } from 'react-redux';
import { Link } from 'react-router-dom';
import { Glyphicon, Nav, Navbar, NavItem } from 'react-bootstrap';
import { LinkContainer } from 'react-router-bootstrap';


const Home = props => (
  <div>
    <h1>Dudatron 2.0</h1>
    <p>Greetings to Dudatron 2.0 </p>

        <p>Login 
               <Link to={'/counter'}> DudaTronReact</Link>

            </p>

    <p>The <code>ClientApp</code> subdirectory is a standard React application based on the <code>create-react-app</code> template. If you open a command prompt in that directory, you can run <code>npm</code> commands such as <code>npm test</code> or <code>npm install</code>.</p>
  </div>
);

export default connect()(Home);
