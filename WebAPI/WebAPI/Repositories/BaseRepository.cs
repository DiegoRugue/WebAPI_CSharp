namespace WebAPI.Repositories {
    public class BaseRepository {
        protected ApplicationContext contexto;
        public BaseRepository(ApplicationContext context) {
            this.contexto = context;
        }

    }
}
