import { About } from './pages/About';
import { Home } from './pages/Home';

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: '/about',
    element: <About />,
  },
];

export default AppRoutes;
