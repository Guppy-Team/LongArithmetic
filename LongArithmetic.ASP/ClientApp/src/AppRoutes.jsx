import {Counter} from './pages/Counter';
import {Home} from './pages/Home';

const AppRoutes = [
  {
    index: true,
    element: <Home />,
  },
  {
    path: '/counter',
    element: <Counter />,
  },
];

export default AppRoutes;