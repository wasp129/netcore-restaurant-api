import Home from "./components/Home/Home";
import Reservation from "./components/Reservation/Reservation";
import './assets/styles/app.scss';
import { BrowserRouter as Router, Switch, Route } from 'react-router-dom';

function App() {
  return (
      <Router>
          <Switch>
              <Route exact path='/' component={Home}/>
              <Route exact path='/reservation/:userId' component={Reservation} />
          </Switch>
      </Router>
  );
}

export default App;
