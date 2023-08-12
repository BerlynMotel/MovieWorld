import './lib/styles/App.css'
import './lib/styles/bootstrap/bootstrap.min.css'
import './lib/styles/bootstrap/bootstrap-grid.min.css'
import './lib/styles/normalize/normalize.css'
import './lib/styles/site.css'
import MainPageLayout from "./layouts/MainPageLayout";
import Header from './components/shared/Header'

function App() {

  return (
    <>
      <Header/>
      <MainPageLayout/>
    </>
  )
}

export default App
