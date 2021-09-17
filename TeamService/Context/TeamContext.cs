using Microsoft.EntityFrameworkCore;
using TeamService.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TeamService.Context
{
    /// <summary>
    /// 团队服务上下文
    /// </summary>
    public class TeamContext : DbContext
    {
        public TeamContext(DbContextOptions<TeamContext> options) : base(options)
        {
        }

        public DbSet<Team> Teams { get; set; }
    }
}
