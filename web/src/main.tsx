import React from 'react'
import ReactDOM from 'react-dom/client'
import App from './App'
import './lib/styles/bootstrap/bootstrap.min.css'
import './lib/styles/bootstrap/bootstrap-grid.min.css'
import './lib/styles/normalize/normalize.css'
import './lib/styles/site.css'

const root = ReactDOM.createRoot(
  document.getElementById('root') as HTMLElement
);

root.render(
  //<React.StrictMode>
    <App />
  //</React.StrictMode>
);