import logo from './logo.svg';
import './App.css';
import SearchAppBar from './components/SearchAppBar';

function App() {
  return (
    //<div className="App">
    //  <header className="App-header">
    //    <img src={logo} className="App-logo" alt="logo" />
    //    <p>
    //      Edit <code>src/App.js</code> and save to reload.
    //    </p>
    //    <a
    //      className="App-link"
    //      href="https://reactjs.org"
    //      target="_blank"
    //      rel="noopener noreferrer"
    //    >
    //      Learn React
    //    </a>
    //  </header>
    //  <SearchAppBar />
    //</div>
    <header>
      <h1>
        Played Well Games
      </h1>
      <SearchAppBar/>
    </header>
  );
}

export default App;
