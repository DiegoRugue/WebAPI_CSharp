﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Repositories {
    public class BaseRepository {
        protected ApplicationContext contexto;
        public BaseRepository(ApplicationContext context) {
            this.contexto = context;
        }

    }
}