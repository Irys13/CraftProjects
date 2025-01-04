import { StrictMode } from 'react'
import { createRoot } from 'react-dom/client'
import './index.css'
import Yarn from './Yarn.jsx'

createRoot(document.getElementById('root')).render(
  <StrictMode>
        <Yarn />
  </StrictMode>,
)
