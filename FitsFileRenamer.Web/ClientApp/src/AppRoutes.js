import { Counter } from "./components/Counter";
import { FetchData } from "./components/FetchData";
import { Home } from "./components/Home";
import { Files} from "./components/Files";

const AppRoutes = [
  {
    index: true,
    element: <Home />
  },
  {
    path: '/files',
    element: <Files />
  },
  {
    path: '/counter',
    element: <Counter />
  },
  {
    path: '/fetch-data',
    element: <FetchData />
  }
];

export default AppRoutes;
