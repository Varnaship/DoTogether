
import { RenderMode, ServerRoute } from '@angular/ssr';
export const serverRoutes: ServerRoute[] = [
  // Parameterized routes removed for fastest build
  { path: '**', renderMode: RenderMode.Prerender }
];
